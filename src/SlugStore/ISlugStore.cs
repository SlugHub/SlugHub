namespace SlugHub.SlugStore
{
    public interface ISlugStore
    {
        bool Exists(string slug, string groupingKey);

        void Store(Slug slug);
    }
}