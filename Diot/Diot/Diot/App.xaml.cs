﻿using Diot.Interface;
using Diot.Services;
using Diot.ViewModels;
using Diot.Views.Extensions;
using Diot.Views.Pages;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Diot
{
    public partial class App
    {
        #region Methods

        #region Constructors

        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="App" /> class.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        public App(IPlatformInitializer initializer) : base(initializer)
        {
        }

        #endregion

        /// <summary>
        ///     Called when the PrismApplication has completed it's initialization process.
        /// </summary>
        protected override async void OnInitialized()
        {
            InitializeComponent();

            ResourceManager.Init(Container.Resolve<IResourceManager>());
            TranslateExtension.Init(new ResourceManager());

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        /// <summary>
        ///     Used to register types with the container that will be used by your application.
        /// </summary>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            #region Navigation

            containerRegistry.Register<IExtendedNavigation, ExtendedNavigation>();

            #endregion

            #region Interfaces

            containerRegistry.Register<IResourceManager, ResourceManager>();

            #endregion

            #region Pages

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<AddNewPage, AddNewPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LibraryPage, LibraryPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();

            #endregion
        }

        #endregion
    }
}