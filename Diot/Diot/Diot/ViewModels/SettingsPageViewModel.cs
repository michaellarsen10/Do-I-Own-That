using Diot.Interface;

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
        public SettingsPageViewModel(IExtendedNavigation navigationService) : base(navigationService)
        {
        }

        #endregion

        #endregion
    }
}