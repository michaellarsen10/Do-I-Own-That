﻿using Diot.ViewModels;
using Diot.Views;
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

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        /// <summary>
        ///     Used to register types with the container that will be used by your application.
        /// </summary>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }

        #endregion
    }
}