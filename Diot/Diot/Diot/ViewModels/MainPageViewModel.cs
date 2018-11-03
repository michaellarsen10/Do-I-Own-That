using Prism.Navigation;

namespace Diot.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Methods

        #region Constructors

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

        #endregion

        #endregion
    }
}