﻿namespace Reginald
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Windows;
    using Caliburn.Micro;
    using Reginald.Services;
    using Reginald.Services.Utilities;
    using Reginald.ViewModels;

    internal class Bootstrapper : BootstrapperBase
    {
        private readonly SimpleContainer _container = new();

        private IntPtr _hMutext = IntPtr.Zero;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void Configure()
        {
            _ = _container.Singleton<IWindowManager, WindowManager>()
                          .Singleton<IEventAggregator, EventAggregator>()
                          .Singleton<DataModelService>()
                          .Singleton<ObjectModelService>()
                          .Singleton<MainViewModel>()
                          .Singleton<ClipboardManagerPopupViewModel>()
                          .Singleton<ShellViewModel>()
                          .Singleton<SettingsViewModel>()
                          .Singleton<GeneralViewModel>()
                          .Singleton<ThemesViewModel>()
                          .Singleton<ExpansionsViewModel>()
                          .Singleton<ClipboardManagerViewModel>()
                          .Singleton<AboutViewModel>()
                          .Singleton<FeaturesViewModel>()
                          .Singleton<WebQueriesViewModel>()
                          .Singleton<YourWebQueriesViewModel>()
                          .Singleton<ApplicationsViewModel>()
                          .Singleton<CalculatorViewModel>()
                          .Singleton<UrlViewModel>()
                          .Singleton<MicrosoftSettingsViewModel>()
                          .Singleton<TimerViewModel>()
                          .Singleton<RecycleViewModel>()
                          .Singleton<QuitViewModel>();
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            if (_hMutext != IntPtr.Zero)
            {
                WindowUtility.UnregisterInstance(_hMutext);
            }

            base.OnExit(sender, e);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            _hMutext = WindowUtility.RegisterInstance("Global\\Reginald");
            if (_hMutext == IntPtr.Zero || Marshal.GetLastWin32Error() == (int)SystemErrorCode.ERROR_ALREADY_EXISTS)
            {
                Application.Current.Shutdown();
            }

            _ = DisplayRootViewFor<ShellViewModel>();
        }
    }
}
