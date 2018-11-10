using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Diot.Helpers;
using Diot.Interface;
using Diot.Models;
using Diot.Services;
using Prism.Services;
using Xamarin.Forms;

namespace Diot.ViewModels
{
    public class AddNewPageViewModel : ViewModelBase
    {
        #region  Fields

        private HttpClientService _httpClientService = new HttpClientService();

        private ImageSource _image;

        private string _movieTitle;

        private string _resultsLabelText;
        private MovieDbModel _currentResult;
        private int _currentResultIndex = -1;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the add new movie command.
        /// </summary>
        public ICommand AddNewMovieCommand => new Command(async () => { await addNewMovie(); });

        /// <summary>
        ///     Gets the delete all movies command.
        /// </summary>
        public ICommand DeleteAllMoviesCommand => new Command(async () => { await deleteAllMovies(); });

        public ICommand SearchMovieCommand => new Command(async () => { await searchMovie(); });

        public ICommand NextResultCommand => new Command(async () => { await loadNextResult(); });

        private async Task loadNextResult()
        {
            if (_searchResults?.Results == null || !_searchResults.Results.Any() ||
                _currentResultIndex + 1 >= _searchResults.Results.Count())
            {
                await DialogService.DisplayAlertAsync("End of results",
                    "There are no other search results found. Try again.", "Ok");
                return;
            }

            CurrentResult = _searchResults.Results[++_currentResultIndex];
        }

        public string MovieTitle
        {
            get => _movieTitle;
            set => SetProperty(ref _movieTitle, value);
        }

        public string ResultsLabelText
        {
            get => _resultsLabelText;
            set => SetProperty(ref _resultsLabelText, value);
        }

        public ImageSource Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

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

        private async Task searchMovie()
        {
            var results = await MoviesDbHelper.SearchMovie(MovieTitle);

            if (results?.Results != null && results.Results.Any())
            {
                _searchResults = results;
                CurrentResult = results.Results[0];
                _currentResultIndex = 0;
            }
            else
            {
                await DialogService.DisplayAlertAsync("No search results", $"No results found for \"{MovieTitle}\" found.", "Ok");
            }

            MovieTitle = string.Empty;
        }

        public MovieDbModel CurrentResult
        {
            get => _currentResult;
            set => SetProperty(ref _currentResult, value, async () =>
            {
                await populateViewModel();
            });
        }

        private string _overview;
        private MovieDbResultsModel _searchResults;

        public string Overview
        {
            get => _overview;
            set => SetProperty(ref _overview, value);
        }

        private async Task populateViewModel()
        {
            Overview = CurrentResult.Overview;

            var imgSrc = await MoviesDbHelper.GetMovieCover(_currentResult.Poster_Path, 400);
            Image = ImageSource.FromStream(() => new MemoryStream(imgSrc));
        }

        /// <summary>
        ///     Deletes all movies.
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
        private async Task addNewMovie()
        {
            if (CurrentResult == null)
            {
                await DialogService.DisplayAlertAsync("Enter movie title", "Please search a movie title to add.", "Ok");
                return;
            }

            DbService.SaveMovie(CurrentResult);

            await NavigationService.GoBackAsync();
        }

        #endregion
    }
}