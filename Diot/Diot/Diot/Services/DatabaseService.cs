using System;
using System.Collections.Generic;
using System.Diagnostics;
using Diot.Interface;
using Diot.Models;
using SQLite;
using Xamarin.Forms;

namespace Diot.Services
{
    public class DatabaseService
    {
        #region  Fields

        private static readonly object locker = new object();
        private readonly SQLiteConnection conn;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="DatabaseService" /> class.
        /// </summary>
        public DatabaseService()
        {
            conn = DependencyService.Get<IDatabaseController>().GetConnection();
            lock (locker)
            {
                try
                {
                    conn.CreateTable<MovieModel>();
                }
                catch (Exception e)
                {
                    Debug.Write(e.Message);
                }
            }
        }

        #endregion

        /// <summary>
        ///     Gets all movies.
        /// </summary>
        public List<MovieModel> GetAllMovies()
        {
            lock (locker)
            {
                return conn.Table<MovieModel>().ToList();
            }
        }

        /// <summary>
        ///     Saves (updates or inserts) a movie.
        /// </summary>
        /// <param name="movie">The movie.</param>
        public int SaveMovie(MovieModel movie)
        {
            lock (locker)
            {
                if (movie.Id == 0)
                {
                    return conn.Insert(movie);
                }

                conn.Update(movie);
                return movie.Id;
            }
        }

        /// <summary>
        ///     Deletes the movie.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public int DeleteMovie(int id)
        {
            lock (locker)
            {
                return conn.Delete(id);
            }
        }

        /// <summary>
        ///     Deletes all movies.
        /// </summary>
        public List<MovieModel> DeleteAllMovies()
        {
            lock (locker)
            {
                conn.DropTable<MovieModel>();
                conn.CreateTable<MovieModel>();
                return conn.Table<MovieModel>().ToList();
            }
        }

        #endregion
    }
}