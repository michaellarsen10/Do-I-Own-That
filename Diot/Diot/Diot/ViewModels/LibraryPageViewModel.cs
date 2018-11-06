using System.Collections.Generic;
using System.Windows.Input;
using Diot.Interface;
using Diot.Models;
using Prism.Navigation;
using Xamarin.Forms;

namespace Diot.ViewModels
{
    public class LibraryPageViewModel : ViewModelBase
    {
        #region  Fields

        private List<MovieModel> _moviesList = new List<MovieModel>();

        #endregion

        #region Properties

        public ICommand AddNewMovieCommand => new Command(addNewMovie);
        public ICommand DeleteAllMoviesCommand => new Command(deleteAllMovies);

        private void deleteAllMovies()
        {
            MoviesList = DbService.DeleteAllMovies();
        }

        public List<MovieModel> MoviesList
        {
            get => _moviesList;
            set => SetProperty(ref _moviesList, value);
        }

        #endregion

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

        private void addNewMovie()
        {
            DbService.SaveMovie(new MovieModel {Title = $"Movie {MoviesList.Count + 1}"});
            MoviesList = DbService.GetAllMovies();
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            MoviesList = DbService.GetAllMovies();
        }

        public string ButtonText => "This is button text";

        #endregion
    }
}