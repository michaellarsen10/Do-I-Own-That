using Diot.Interface;
using Prism.Services;

namespace Diot.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        #region Methods

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="SettingsPageViewModel" /> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="dialogService">The dialog service.</param>
        public SettingsPageViewModel(IExtendedNavigation navigationService, IPageDialogService dialogService) 
            : base(navigationService, dialogService)
        {
        }

        #endregion

        #endregion
    }
}