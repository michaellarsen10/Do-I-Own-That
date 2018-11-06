using System.Threading.Tasks;
using System.Windows.Input;
using Diot.Interface;
using Diot.Models;
using Prism.Services;
using Xamarin.Forms;

namespace Diot.ViewModels
{
    public class AddNewPageViewModel : ViewModelBase
    {
        #region Properties

        /// <summary>
        ///     Gets the add new movie command.
        /// </summary>
        public ICommand AddNewMovieCommand => new Command(addNewMovie);

        /// <summary>
        ///     Gets the delete all movies command.
        /// </summary>
        public ICommand DeleteAllMoviesCommand => new Command(async () => { await deleteAllMovies(); });

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="AddNewPageViewModel" /> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="pageDialogService">The page dialog service.</param>
        public AddNewPageViewModel(IExtendedNavigation navigationService,
            IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
        }

        #endregion

        /// <summary>
        ///  Deletes all movies.
        /// </summary>
        private async Task deleteAllMovies()
        {
            await DialogService.DisplayAlertAsync("Delete all movies",
                "Are you sure you want to delete all movies?",
                "Ok");

            DbService.DeleteAllMovies();
        }

        /// <summary>
        ///     Adds the new movie.
        /// </summary>
        private void addNewMovie()
        {
            var moviesList = DbService.GetAllMovies();
            var title = $"Movie {moviesList.Count + 1}";

            DbService.SaveMovie(new MovieModel
            {
                Title = title,
                OtherComment = $"This is another comment for {title}"
            });

            NavigationService.GoBackAsync();
        }

        #endregion
    }
}