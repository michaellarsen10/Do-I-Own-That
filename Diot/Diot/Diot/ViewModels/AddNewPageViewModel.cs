using Diot.Interface;
using Prism.Navigation;

namespace Diot.ViewModels
{
    public class AddNewPageViewModel : ViewModelBase
    {
        #region Methods

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AddNewPageViewModel" /> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        public AddNewPageViewModel(IExtendedNavigation navigationService) : base(navigationService)
        {
        }

        #endregion

        #endregion
    }
}