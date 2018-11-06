using System.Collections.Generic;
using Diot.Interface;
using Diot.Models;
using Prism.Navigation;
using Prism.Services;

namespace Diot.ViewModels
{
    public class LibraryPageViewModel : ViewModelBase
    {
        #region  Fields

        private List<MovieModel> _moviesList = new List<MovieModel>();

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the movies list.
        /// </summary>
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
        /// <param name="dialogService">The dialog service.</param>
        public LibraryPageViewModel(IExtendedNavigation navigationService, 
            IPageDialogService dialogService) : base(navigationService, dialogService)
        {
        }

        #endregion

        /// <summary>
        ///     Called when [navigating to].
        /// </summary>
        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            MoviesList = DbService.GetAllMovies();
        }

        #endregion
    }
}