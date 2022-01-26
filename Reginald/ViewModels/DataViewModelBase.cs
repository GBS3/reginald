﻿namespace Reginald.ViewModels
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Caliburn.Micro;
    using Reginald.Core.AbstractProducts;
    using Reginald.Core.Clients;
    using Reginald.Core.DataModels;
    using Reginald.Core.Factories;
    using Reginald.Core.Helpers;
    using Reginald.Core.IO;
    using Reginald.Core.Products;

    public class DataViewModelBase : Screen
    {
        private SettingsDataModel _settings = new();

        private IEnumerable<ShellItem> _applications;

        private Theme _theme;

        private IEnumerable<Keyword> _defaultKeywords;

        private IEnumerable<Keyword> _userKeywords;

        private IEnumerable<Keyword> _defaultResults;

        private IEnumerable<Keyword> _commands;

        private IEnumerable<Keyword> _httpKeywords;

        private IEnumerable<Keyphrase> _utilities;

        private Representation _calculator;

        private Representation _link;

        private bool _systemUsesLightTheme;

        private bool _requiresRefresh;

        public DataViewModelBase(bool monitorChanges)
        {
            UpdateSettings();
            Theme = UpdateUnit<ThemeDataModel>(ApplicationPaths.ThemesJsonFilename, true, Settings.ThemeIdentifier) as Theme;

            if (monitorChanges)
            {
                SystemUsesLightTheme = HandyControl.Tools.WindowHelper.DetermineIfInLightThemeMode();

                Applications = UpdateShellItems();
                DefaultKeywords = UpdateKeywords<GenericKeywordDataModel>(ApplicationPaths.KeywordsJsonFilename, true, true);
                UserKeywords = UpdateKeywords<GenericKeywordDataModel>(ApplicationPaths.UserKeywordsJsonFilename, false, true);
                DefaultResults = UpdateKeywords<GenericKeywordDataModel>(ApplicationPaths.DefaultResultsJsonFilename, true, true);
                Commands = UpdateKeywords<CommandDataModel>(ApplicationPaths.CommandsJsonFilename, true, true);
                HttpKeywords = UpdateKeywords<HttpKeywordDataModel>(ApplicationPaths.HttpKeywordsJsonFilename, true, true);
                Utilities = UpdateKeyphrases<UtilityDataModel>(ApplicationPaths.UtilitiesJsonFilename);
                MicrosoftSettings = UpdateKeyphrases<MicrosoftSettingDataModel>(ApplicationPaths.MicrosoftSettingsJsonFilename);
                Calculator = UpdateRepresentation<CalculatorDataModel>(ApplicationPaths.CalculatorJsonFilename);
                Link = UpdateRepresentation<LinkDataModel>(ApplicationPaths.LinkJsonFilename);

                string appDataDirectoryPath = ApplicationPaths.AppDataDirectoryPath;
                string applicationName = ApplicationPaths.ApplicationName;
                string appDataApplicationDirectoryPath = Path.Combine(appDataDirectoryPath, applicationName);

                SettingsWatcher = FileSystemWatcherHelper.Initialize(appDataApplicationDirectoryPath, ApplicationPaths.SettingsFilename, OnSettingsChanged);
                DefaultKeywordsWatcher = FileSystemWatcherHelper.Initialize(appDataApplicationDirectoryPath, ApplicationPaths.KeywordsJsonFilename, OnDefaultKeywordsChanged);
                UserKeywordsWatcher = FileSystemWatcherHelper.Initialize(appDataApplicationDirectoryPath, ApplicationPaths.UserKeywordsJsonFilename, OnUserKeywordsChanged);
                CommandsWatcher = FileSystemWatcherHelper.Initialize(appDataApplicationDirectoryPath, ApplicationPaths.CommandsJsonFilename, OnCommandsChanged);
            }
        }

        public SearchTermFactory SearchTermFactory { get; set; } = new();

        public IEnumerable<Keyphrase> MicrosoftSettings { get; set; }

        public SettingsDataModel Settings
        {
            get => _settings;
            set
            {
                _settings = value;
                NotifyOfPropertyChange(() => Settings);
            }
        }

        public Theme Theme
        {
            get => _theme;
            set
            {
                _theme = value;
                NotifyOfPropertyChange(() => Theme);
            }
        }

        public IEnumerable<ShellItem> Applications
        {
            get => _applications;
            set
            {
                _applications = value;
                NotifyOfPropertyChange(() => Applications);
            }
        }

        public IEnumerable<Keyword> DefaultKeywords
        {
            get => _defaultKeywords;
            set
            {
                _defaultKeywords = value;
                NotifyOfPropertyChange(() => DefaultKeywords);
            }
        }

        public IEnumerable<Keyword> UserKeywords
        {
            get => _userKeywords;
            set
            {
                _userKeywords = value;
                NotifyOfPropertyChange(() => UserKeywords);
            }
        }

        public IEnumerable<Keyword> DefaultResults
        {
            get => _defaultResults;
            set
            {
                _defaultResults = value;
                NotifyOfPropertyChange(() => DefaultResults);
            }
        }

        public IEnumerable<Keyword> Commands
        {
            get => _commands;
            set
            {
                _commands = value;
                NotifyOfPropertyChange(() => Commands);
            }
        }

        public IEnumerable<Keyword> HttpKeywords
        {
            get => _httpKeywords;
            set
            {
                _httpKeywords = value;
                NotifyOfPropertyChange(() => HttpKeywords);
            }
        }

        public IEnumerable<Keyphrase> Utilities
        {
            get => _utilities;
            set
            {
                _utilities = value;
                NotifyOfPropertyChange(() => Utilities);
            }
        }

        public Representation Calculator
        {
            get => _calculator;
            set
            {
                _calculator = value;
                NotifyOfPropertyChange(() => Calculator);
            }
        }

        public Representation Link
        {
            get => _link;
            set
            {
                _link = value;
                NotifyOfPropertyChange(() => Link);
            }
        }

        public bool SystemUsesLightTheme
        {
            get => _systemUsesLightTheme;
            set
            {
                if (_systemUsesLightTheme != value)
                {
                    _systemUsesLightTheme = value;
                    string filename = _systemUsesLightTheme ? ApplicationPaths.DynamicThemesJsonFilename : ApplicationPaths.ThemesJsonFilename;
                    Theme = UpdateUnit<ThemeDataModel>(filename, true, Settings.ThemeIdentifier) as Theme;
                    NotifyOfPropertyChange(() => SystemUsesLightTheme);
                }
            }
        }

        public bool RequiresRefresh
        {
            get => _requiresRefresh;
            set
            {
                _requiresRefresh = value;
                NotifyOfPropertyChange(() => RequiresRefresh);
            }
        }

        private FileSystemWatcher SettingsWatcher { get; set; }

        private FileSystemWatcher DefaultKeywordsWatcher { get; set; }

        private FileSystemWatcher UserKeywordsWatcher { get; set; }

        private FileSystemWatcher CommandsWatcher { get; set; }

        public static Unit UpdateUnit<T>(string filename, bool isResource, string parameter)
        {
            IEnumerable<UnitDataModelBase> models = FileOperations.GetUnitData<T>(filename, isResource);
            UnitDataModelBase unit = models.FirstOrDefault(m => m.Predicate(parameter)) ?? models.First();
            UnitClient client = new(new AccessoryFactory(), unit);
            return client.Unit;
        }

        public static IEnumerable<Unit> UpdateUnits<T>(string filename, bool isResource)
        {
            IEnumerable<UnitDataModelBase> models = FileOperations.GetUnitData<T>(filename, isResource);
            AccessoryFactory factory = new();
            UnitClient client = new(factory, models);
            return client.Units;
        }

        public void UpdateTheme(string filename, bool isResource)
        {
            IEnumerable<ThemeDataModel> models = FileOperations.GetGenericData<ThemeDataModel>(filename, isResource);
            AccessoryFactory factory = new();
            UnitClient client = new(factory, models.First(m => m.Guid == Settings.ThemeIdentifier));
            Theme = client.Unit as Theme;
        }

        public IEnumerable<Keyword> UpdateKeywords<T>(string filename, bool isResource, bool filter)
        {
            IEnumerable<KeywordDataModelBase> models = filter
                                                     ? FileOperations.GetKeywordData<T>(filename, isResource)
                                                                     .Where(k => k.IsEnabled)
                                                     : FileOperations.GetKeywordData<T>(filename, isResource);
            if (models is not null)
            {
                KeywordClient client = new(SearchTermFactory, models);
                return client.Keywords;
            }

            return Enumerable.Empty<Keyword>();
        }

        public IEnumerable<Keyphrase> UpdateKeyphrases<T>(string filename)
        {
            IEnumerable<KeyphraseDataModelBase> models = FileOperations.GetKeyphraseData<T>(filename, true);
            if (models is not null)
            {
                KeyphraseClient client = new(SearchTermFactory, models);
                return client.Keyphrases;
            }

            return Enumerable.Empty<Keyphrase>();
        }

        private static Representation UpdateRepresentation<T>(string filename)
        {
            InputDataModelBase model = FileOperations.GetRepresentationDatum<T>(filename, true);
            RepresentationFactory factory = new();
            RepresentationClient client = new(factory, model);
            return client.Representation;
        }

        private void UpdateSettings()
        {
            SettingsDataModel settings = FileOperations.GetSettingsData(ApplicationPaths.SettingsFilename);
            if (settings is not null)
            {
                Settings = settings;
            }
        }

        private IEnumerable<ShellItem> UpdateShellItems()
        {
            ShellItemClient client = new(SearchTermFactory, WindowsShell.GetApplications());
            return client.ShellItems;
        }

        private void OnSettingsChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                UpdateSettings();

                bool previousRequiresRefresh = Theme.RequiresRefresh;
                Theme = UpdateUnit<ThemeDataModel>(ApplicationPaths.ThemesJsonFilename, true, Settings.ThemeIdentifier) as Theme;
                if (!previousRequiresRefresh && Theme.RequiresRefresh)
                {
                    RequiresRefresh = Theme.RequiresRefresh;
                }
            }
        }

        private void OnDefaultKeywordsChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                DefaultKeywords = UpdateKeywords<GenericKeywordDataModel>(ApplicationPaths.KeywordsJsonFilename, true, true);
            }
        }

        private void OnUserKeywordsChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                UserKeywords = UpdateKeywords<GenericKeywordDataModel>(ApplicationPaths.UserKeywordsJsonFilename, false, true);
            }
        }

        private void OnCommandsChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                Commands = UpdateKeywords<CommandDataModel>(ApplicationPaths.CommandsJsonFilename, true, true);
            }
        }
    }
}
