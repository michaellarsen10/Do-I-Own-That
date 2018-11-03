using Prism.Mvvm;
using Prism.Navigation;

namespace Diot.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        #region  Fields

        private string _title;

        #endregion

        #region Properties

        protected INavigationService NavigationService { get; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        #endregion

        #region Methods

        #region Constructors

        public ViewModelBase(INavigationService navigationService)
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