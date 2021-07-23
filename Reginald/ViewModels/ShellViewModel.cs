﻿using Caliburn.Micro;
using Hardcodet.Wpf.TaskbarNotification;
using Reginald.Commands;
using Reginald.Core.IO;
using Reginald.Core.Utils;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace Reginald.ViewModels
{
    public class Indicator
    {
        private bool _isDeactivated;
        public bool IsDeactivated
        {
            get => _isDeactivated;
            set
            {
                _isDeactivated = value;
                ShellViewModel.SearchViewModel.TryCloseAsync();
                ShellViewModel.SearchViewModel = new SearchViewModel(new Indicator());
            }
        }
    }

    public class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
            tb = (TaskbarIcon)Application.Current.FindResource("ReginaldNotifyIcon");
            OpenWindowCommand = new OpenWindowCommand(ExecuteMethod, CanExecuteMethod);

            // Creates "Reginald" in %AppData%
            Directory.CreateDirectory(Path.Combine(ApplicationPaths.AppDataDirectoryPath, ApplicationPaths.ApplicationName));

            // Creates "Reginald\UserIcons" in %AppData%
            string path = Path.Combine(ApplicationPaths.AppDataDirectoryPath, ApplicationPaths.ApplicationName, ApplicationPaths.UserIconsDirectoryName);
            Directory.CreateDirectory(path);

            // Creates and updates "Reginald\Search.xml" in %AppData%
            //FileOperations.MakeDefaultKeywordXmlFile();
            string defaultKeywordsXml = FileOperations.GetDefaultKeywordsXml();
            FileOperations.MakeXmlFile(defaultKeywordsXml, ApplicationPaths.XmlKeywordFilename);
            FileOperations.UpdateXmlFile(defaultKeywordsXml, ApplicationPaths.XmlKeywordFilename);

            // Creates and updates "Reginald\SpecialKeywords.xml" in %AppData%
            string specialKeywordsXml = FileOperations.GetSpecialKeywordsXml();
            FileOperations.MakeXmlFile(specialKeywordsXml, ApplicationPaths.XmlSpecialKeywordFilename);
            FileOperations.UpdateXmlFile(specialKeywordsXml, ApplicationPaths.XmlSpecialKeywordFilename);

            FileOperations.CacheApplicationIcons();

            // Creates "Reginald\Applications.txt" in %AppData%
            FileOperations.MakeApplicationsTextFile();

            // Creates "Reginald\UserSearch.xml" in %AppData%
            FileOperations.MakeUserKeywordsXmlFile();

            SearchViewModel = new(new Indicator());
            SetUpAsync();
        }

        // NotifyIcon for System Tray
        private TaskbarIcon tb;

        public static SearchViewModel SearchViewModel { get; set; }
        public static Indicator Indicator { get; set; }

        public ICommand OpenWindowCommand { get; set; }

        private bool CanExecuteMethod(object parameter)
        {
            return true;
        }

        private async void ExecuteMethod(object parameter)
        {
            if (SearchViewModel.IsActive)
            {
                await SearchViewModel.TryCloseAsync();
            }
            else
            {
                IWindowManager manager = new WindowManager();
                await manager.ShowWindowAsync(SearchViewModel);
            }
        }

        private async static void SetUpAsync()
        {
            CancellationToken cancellationToken = new();
            await TimerUtils.DoEveryTenSecondsAsync(cancellationToken);
        }
    }
}
