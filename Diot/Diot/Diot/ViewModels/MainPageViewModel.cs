using System.Threading.Tasks;
using System.Windows.Input;
using Diot.Helpers;
using Diot.Interface;
using Xamarin.Forms;

namespace Diot.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Properties

        /// <summary>
        ///     Gets the navigate to add new page command.
        /// </summary>
        public ICommand NavigateToAddNewPageCommand => new Command(async () => { await navigateToAddNewPage(); });

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainPageViewModel" /> class.
        /// </summary>
        public MainPageViewModel(IExtendedNavigation navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

        #endregion

        /// <summary>
        ///     Navigates to add new page.
        /// </summary>
        private async Task navigateToAddNewPage()
        {
            await NavigationService.NavigateAsync(PageNames.AddNewPage);
        }

        #endregion
    }
}