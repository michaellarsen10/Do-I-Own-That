using Diot.Interface;

namespace Diot.ViewModels
{
    public class LibraryPageViewModel : ViewModelBase
    {
        #region Methods

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="LibraryPageViewModel" /> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        public LibraryPageViewModel(IExtendedNavigation navigationService) : base(navigationService)
        {
        }

        #endregion

        #endregion
    }
}