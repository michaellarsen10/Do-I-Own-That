using Prism.Navigation;

namespace Diot.ViewModels
{
    public class Page1ViewModel : ViewModelBase
    {
        #region Methods

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Page1ViewModel" /> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        public Page1ViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        #endregion

        #endregion
    }
}