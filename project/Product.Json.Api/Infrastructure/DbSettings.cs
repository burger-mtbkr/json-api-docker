namespace Product.Json.Api.Infrastructure
{
    public record DatabaseSettings
    {
        private const string DefaultDb = "default-db.json";

        /// <summary>
        /// File path db json used to seed the database.
        /// </summary>
        public string FilePath { get; init; } = DefaultDb;

        /// <summary>
        /// If a custom database file is used we enable live reloading by default.
        /// </summary>
        public bool LiveReload => FilePath != DefaultDb;
    }
}
