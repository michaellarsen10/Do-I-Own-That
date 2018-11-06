using SQLite;

namespace Diot.Models
{
    [Table("Movies")]
    public class MovieModel
    {
        public enum MediaFormat
        {
            Dvd,
            Bluray,
            UHD,
            Vudu,
            MoviesAnywhere,
            Plex,
            Amazon,
            Other
        }

        #region Properties

        /// <summary>
        ///     Gets the identifier.
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is on DVD.
        /// </summary>
        public bool IsOnDvd { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is on bluray.
        /// </summary>
        public bool IsOnBluray { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is on uhd.
        /// </summary>
        public bool IsOnUhd { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is on vudu.
        /// </summary>
        public bool IsOnVudu { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is on movies anywhere.
        /// </summary>
        public bool IsOnMoviesAnywhere { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is on plex.
        /// </summary>
        public bool IsOnPlex { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is on amazon.
        /// </summary>
        public bool IsOnAmazon { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is on other.
        /// </summary>
        public bool IsOnOther { get; set; }

        /// <summary>
        ///     Gets or sets comment when format is other.
        /// </summary>
        public string OtherComment { get; set; }

        #endregion
    }
}