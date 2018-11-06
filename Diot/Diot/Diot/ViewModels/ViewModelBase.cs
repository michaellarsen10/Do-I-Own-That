using Diot.Interface;
using Diot.Services;
using Prism.Mvvm;
using Prism.Navigation;

namespace Diot.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        #region  Fields

        private static DatabaseService databaseService;

        private string _title;

        #endregion

        #region Properties

        public IExtendedNavigation NavigationService { get; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        /// <summary>
        ///     Gets the database service.
        /// </summary>
        public static DatabaseService DbService => databaseService ?? (databaseService = new DatabaseService());

        #endregion

        #region Methods

        #region Constructors

        public ViewModelBase(IExtendedNavigation navigationService)
        {
            NavigationService = navigationService;
        }

        #endregion

        public virtual void Destroy()
        {
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
        }

        #endregion
    }
}