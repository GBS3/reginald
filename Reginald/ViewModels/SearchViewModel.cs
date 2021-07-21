﻿using Caliburn.Micro;
using Reginald.Core.Base;
using Reginald.Core.Enums;
using Reginald.Core.Helpers;
using Reginald.Core.IO;
using Reginald.Extensions;
using Reginald.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;

namespace Reginald.ViewModels
{
    public class SearchViewModel : Screen
    {
        protected override Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
        {
            Indicator.IsDeactivated = true;
            return base.OnDeactivateAsync(close, cancellationToken);
        }

        public SearchViewModel(Indicator indicator)
        {
            Indicator = indicator;
            SetUpViewModel();
        }

        private string applicationImagesDirectoryPath;
        private string applicationsTxtFilePath;
        private XmlDocument searchDoc;
        private XmlDocument userSearchDoc;
        private Dictionary<string, string> applicationsDict;

        private Indicator _indicator;
        public Indicator Indicator
        {
            get => _indicator;
            set
            {
                _indicator = value;
            }
        }

        private SettingsModel _settings = new();
        public SettingsModel Settings
        {
            get => _settings;
            set
            {
                _settings = value;
                NotifyOfPropertyChange(() => Settings);
            }
        }

        private string _userInput;
        public string UserInput
        {
            get => _userInput;
            set
            {
                _userInput = value;
                NotifyOfPropertyChange(() => UserInput);
                foreach (SearchResultModel model in SearchResults)
                {
                    if (model.Category == Category.Application)
                    {
                        continue;
                    }
                    else if (model.Category == Category.Math)
                    {
                        model.Text = value.Eval();
                    }
                    else if (model.Category == Category.Keyword)
                    {
                        (string left, _, string right) = value.Partition(" ");
                        model.Text = right == String.Empty ? model.DefaultText : right;
                    }
                    else
                        model.Text = value;

                    model.Description = String.Format(model.Format, model.Text);
                }
            }
        }

        private BindableCollection<SearchResultModel> _searchResults = new();
        public BindableCollection<SearchResultModel> SearchResults
        {
            get => _searchResults;
            set
            {
                _searchResults = value;
                NotifyOfPropertyChange(() => SearchResults);
                IsVisible = SearchResults.Count == 0 ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        private SearchResultModel _selectedSearchResult = new();
        public SearchResultModel SelectedSearchResult
        {
            get => _selectedSearchResult;
            set
            {
                LastSelectedSearchResult = SelectedSearchResult;
                _selectedSearchResult = value;
                NotifyOfPropertyChange(() => SelectedSearchResult);
            }
        }

        private SearchResultModel _lastSelectedSearchResult;
        public SearchResultModel LastSelectedSearchResult
        {
            get => _lastSelectedSearchResult;
            set
            {
                _lastSelectedSearchResult = value;
                NotifyOfPropertyChange(() => LastSelectedSearchResult);
            }
        }

        private Visibility _isVisible;
        public Visibility IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                NotifyOfPropertyChange(() => IsVisible);
            }
        }

        private async void SetUpViewModel()
        {
            applicationImagesDirectoryPath = Path.Combine(ApplicationPaths.AppDataDirectoryPath, ApplicationPaths.ApplicationName, ApplicationPaths.IconsDirectoryName);
            applicationsTxtFilePath = Path.Combine(ApplicationPaths.AppDataDirectoryPath, ApplicationPaths.ApplicationName, ApplicationPaths.TxtFilename);
            searchDoc = XmlHelper.GetXmlDocument(ApplicationPaths.XmlKeywordFilename);
            userSearchDoc = XmlHelper.GetXmlDocument(ApplicationPaths.XmlUserKeywordFilename);
            applicationsDict = await Task.Run(() =>
            {
                return Applications.MakeDictionary();
            });

            Properties.Settings settings = Properties.Settings.Default;
            System.Drawing.Color searchBackgroundColor;
            System.Drawing.Color searchDescriptionTextColor;
            System.Drawing.Color searchAltTextColor;
            System.Drawing.Color searchInputTextColor;
            System.Drawing.Color searchInputCaretColor;
            System.Drawing.Color searchViewBorderColor;
            if (settings.IsDarkModeEnabled)
            {
                searchBackgroundColor = settings.SearchBackgroundColorDark;
                searchDescriptionTextColor = settings.SearchDescriptionTextColorDark;
                searchAltTextColor = settings.SearchAltTextColorDark;
                searchInputTextColor = settings.SearchInputTextColorDark;
                searchInputCaretColor = settings.SearchInputCaretColorDark;
                searchViewBorderColor = settings.SearchViewBorderColorDark;
            }
            else
            {
                searchBackgroundColor = settings.SearchBackgroundColorLight;
                searchDescriptionTextColor = settings.SearchDescriptionTextColorLight;
                searchAltTextColor = settings.SearchAltTextColorLight;
                searchInputTextColor = settings.SearchInputTextColorLight;
                searchInputCaretColor = settings.SearchInputCaretColorLight;
                searchViewBorderColor = settings.SearchViewBorderColorLight;
            }
            Settings.SearchBackgroundColor = Color.FromRgb(searchBackgroundColor.R, searchBackgroundColor.G, searchBackgroundColor.B);
            Settings.SearchDescriptionTextBrush = new SolidColorBrush(Color.FromRgb(searchDescriptionTextColor.R, searchDescriptionTextColor.G, searchDescriptionTextColor.B));
            Settings.SearchAltTextBrush = new SolidColorBrush(Color.FromRgb(searchAltTextColor.R, searchAltTextColor.G, searchAltTextColor.B));
            Settings.SearchInputTextBrush = new SolidColorBrush(Color.FromRgb(searchInputTextColor.R, searchInputTextColor.G, searchInputTextColor.B));
            Settings.SearchInputCaretBrush = new SolidColorBrush(Color.FromRgb(searchInputCaretColor.R, searchInputCaretColor.G, searchInputCaretColor.B));
            Settings.SearchViewBorderBrush = new SolidColorBrush(Color.FromRgb(searchViewBorderColor.R, searchViewBorderColor.G, searchViewBorderColor.B));
        }

        public async void UserInput_TextChangedAsync(object sender, TextChangedEventArgs e)
        {
            if (UserInput != String.Empty)
            {
                IEnumerable<SearchResultModel> models;
                Task<IEnumerable<SearchResultModel>> applicationModelsTask;
                Task<IEnumerable<SearchResultModel>> keywordModelsTask;
                Task<IEnumerable<SearchResultModel>> userKeywordModelsTask;
                Task<SearchResultModel[]> mathModelsTask = null;

                if (UserInput.HasScheme() || UserInput.HasTopLevelDomain())
                {
                    models = SearchResultModel.MakeArray(searchDoc, UserInput, "__http", Category.HTTP);
                }
                else
                {
                    applicationModelsTask = Task.Run(() =>
                    {
                        if (Properties.Settings.Default.IncludeInstalledApplications)
                            return GetApplications(UserInput);
                        return Enumerable.Empty<SearchResultModel>();
                    });

                    keywordModelsTask = Task.Run(() =>
                    {
                        if (Properties.Settings.Default.IncludeDefaultKeywords)
                        {
                            (string Left, string Separator, string Right) partition = UserInput.Partition(" ");

                            List<string> attributes = searchDoc.GetNodesAttributes(Constants.NamespacesXpath);
                            string format = @"((?<!\w){0}.*)";
                            Regex rx = new(String.Format(format, partition.Left.Replace("[", "\\[")), RegexOptions.IgnoreCase);
                            IEnumerable<string> matches = attributes.Where(x => rx.IsMatch(x))
                                                                    .Distinct();

                            IEnumerable<SearchResultModel> keywordModels = Array.Empty<SearchResultModel>();
                            foreach (string match in matches)
                            {
                                keywordModels = keywordModels.Concat(SearchResultModel.MakeList(searchDoc, partition.Right, match, Category.Keyword));
                            }
                            return keywordModels;
                        }
                        return Enumerable.Empty<SearchResultModel>();
                    });

                    userKeywordModelsTask = Task.Run(() =>
                    {
                        (string Left, string Separator, string Right) partition = UserInput.Partition(" ");

                        List<string> attributes = userSearchDoc.GetNodesAttributes(Constants.NamespacesXpath);
                        string format = @"((?<!\w){0}.*)";
                        Regex rx = new(String.Format(format, partition.Left.Replace("[", "\\[")), RegexOptions.IgnoreCase);
                        IEnumerable<string> matches = attributes.Where(x => rx.IsMatch(x))
                                                                .Distinct();

                        IEnumerable<SearchResultModel> userKeywordModels = Array.Empty<SearchResultModel>();
                        foreach (string match in matches)
                        {
                            userKeywordModels = userKeywordModels.Concat(SearchResultModel.MakeList(userSearchDoc, partition.Right, match, Category.Keyword));
                        }
                        return userKeywordModels;
                    });

                    mathModelsTask = Task.Run(() =>
                    {
                        if (UserInput.IsMathExpression())
                        {
                            return SearchResultModel.MakeArray(searchDoc, UserInput, "__math", Category.Math, UserInput.Eval());
                        }
                        return Array.Empty<SearchResultModel>();
                    });

                    IEnumerable<SearchResultModel> applicationModels = await applicationModelsTask;
                    IEnumerable<SearchResultModel> keywordModels = await keywordModelsTask;
                    IEnumerable<SearchResultModel> userKeywordModels = await userKeywordModelsTask;
                    SearchResultModel[] mathModels = await mathModelsTask;

                    try
                    {
                        models = applicationModels.Concat(keywordModels).Concat(userKeywordModels).Concat(mathModels);
                    }
                    catch (ArgumentNullException)
                    {
                        return;
                    }

                    if (!models.Any())
                    {
                        models = new SearchResultModel[3]
                        {
                            new SearchResultModel(searchDoc, UserInput, "g", Category.SearchEngine),
                            new SearchResultModel(searchDoc, UserInput, "ddg", Category.SearchEngine),
                            new SearchResultModel(searchDoc, UserInput, "amazon", Category.SearchEngine),
                        };
                    }
                }

                SearchResults.Clear();
                SearchResults.AddRange(models);
                SelectedSearchResult = SearchResults[0];
            }
            else
            {
                SearchResults.Clear();
            }
        }

        private IEnumerable<SearchResultModel> GetApplications(string input)
        {
            List<SearchResultModel> applications = new();
            List<string> applicationNames = new();
            Regex rx;
            try
            {
                string format = @".*((?<![a-z]){0}.*)";
                rx = new(String.Format(format, input), RegexOptions.IgnoreCase);
            }
            catch (RegexParseException)
            {
                return Enumerable.Empty<SearchResultModel>();
            }

            using (StreamReader sr = new(applicationsTxtFilePath))
            {
                string fileContent = sr.ReadToEnd();
                MatchCollection matches = rx.Matches(fileContent);
                foreach (Match match in matches)
                {
                    applicationNames.Add(match.Value.Trim());
                }
            }
            foreach (string name in applicationNames)
            {
                if (applicationsDict.TryGetValue(name, out string value))
                {
                    applications.Add(new SearchResultModel(name, value, GetApplicationIcon(applicationImagesDirectoryPath, name)));
                }
            }
            return applications.OrderByDescending(x => x.Name.StartsWith(input[0].ToString(), StringComparison.InvariantCultureIgnoreCase))
                               .ThenBy(x => x.Name);
        }

        private BitmapImage GetApplicationIcon(string path, string name)
        {
            string iconPath = Path.Combine(path, name + ".png");
            if (!File.Exists(iconPath))
            {
                iconPath = "pack://application:,,,/Reginald;component/Images/help-light.png";
            }

            BitmapImage icon = new();
            icon.BeginInit();
            icon.UriSource = new Uri(iconPath);
            icon.CacheOption = BitmapCacheOption.OnLoad;
            icon.DecodePixelWidth = 75;
            icon.DecodePixelHeight = 75;
            icon.EndInit();
            icon.Freeze();
            return icon;
        }

        public void UserInput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    try
                    {
                        HandleSelectedSearchResultBasedOnCategoryName(SelectedSearchResult.Category);
                    }
                    catch (NullReferenceException) { }
                    e.Handled = true;
                    break;

                case Key.Up:
                    try
                    {
                        SelectedSearchResult = SearchResults[SearchResults.IndexOf(SelectedSearchResult) - 1];
                    }
                    catch (ArgumentOutOfRangeException) { }
                    break;

                case Key.Down:
                    try
                    {
                        SelectedSearchResult = SearchResults[SearchResults.IndexOf(SelectedSearchResult) + 1];
                    }
                    catch (ArgumentOutOfRangeException) { }
                    break;

                case Key.Tab:
                    TextBox textBox = (TextBox)sender;
                    if (SelectedSearchResult.Keyword is not null)
                    {
                        if (!UserInput.StartsWith(SelectedSearchResult.Keyword, StringComparison.InvariantCultureIgnoreCase))
                        {
                            UserInput = SelectedSearchResult.Keyword;
                            textBox.SelectionStart = UserInput.Length;
                        }
                    }
                    else
                    {
                        if (!UserInput.StartsWith(SelectedSearchResult.Name, StringComparison.InvariantCultureIgnoreCase))
                        {
                            UserInput = SelectedSearchResult.Name;
                            textBox.SelectionStart = UserInput.Length;
                        }
                    }
                    e.Handled = true;
                    break;

                default:
                    break;
            }
        }

        public void SearchResults_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HandleSelectedSearchResultBasedOnCategoryName(SelectedSearchResult.Category);
        }

        private void HandleSelectedSearchResultBasedOnCategoryName(Category category)
        {
            switch (category)
            {
                case Category.Application:
                    Process.Start("explorer.exe", @"shell:appsfolder\" + SelectedSearchResult.ParsingName);
                    TryCloseAsync();
                    break;

                case Category.Math:
                    Clipboard.SetText(SelectedSearchResult.Text);
                    TryCloseAsync();
                    break;

                case Category.Keyword:
                    {
                        string uri = String.Format(SelectedSearchResult.URL, SelectedSearchResult.Text);
                        GoToWebsite(uri);
                        break;
                    }

                case Category.HTTP:
                    {
                        string uri = UserInput;
                        if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
                            uri = uri.PrependScheme();
                        GoToWebsite(uri);
                        break;
                    }

                case Category.SearchEngine:
                    {
                        string uri = String.Format(SelectedSearchResult.URL, UserInput.Quote(SelectedSearchResult.Separator));
                        GoToWebsite(uri);
                        break;
                    }

                default:
                    break;
            }
        }

        public void SearchResults_MouseLeave(object sender, MouseEventArgs e)
        {
            try
            {
                SelectedSearchResult = LastSelectedSearchResult;
            }
            catch (ArgumentOutOfRangeException) { }
        }

        public void SearchResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (sender as ListBox).ScrollIntoView(SelectedSearchResult);
        }

        private static void GoToWebsite(string uri)
        {
            try
            {
                ProcessStartInfo startInfo = new()
                {
                    FileName = uri,
                    UseShellExecute = true
                };
                Process.Start(startInfo);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                if (ex.ErrorCode == -2147467259)
                    MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}