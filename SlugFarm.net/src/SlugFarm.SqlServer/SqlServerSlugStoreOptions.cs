namespace SlugFarm.SqlServer
{
    public class SqlServerSlugStoreOptions
    {
        public SqlServerSlugStoreOptions()
        {
            //defaults
            TableSchema = "SlugFarm";
            TableName = "Slugs";
        }

        public string TableName { get; set; }

        public string TableSchema { get; set; }
    }
}