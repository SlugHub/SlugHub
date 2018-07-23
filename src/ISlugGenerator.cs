namespace SlugHub
{
    public interface ISlugGenerator
    {
        string GenerateSlug(string text, string[] uniquifiers = null);

        string GenerateSlug(string text, string groupingKey, string[] uniquifiers = null);
    }
}