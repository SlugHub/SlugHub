using System.Threading.Tasks;

namespace SlugHub
{
    public interface ISlugGenerator
    {
        Task<string> GenerateSlug(string text, string[] uniquifiers = null);

        Task<string> GenerateSlug(string text, string groupingKey, string[] uniquifiers = null);
    }
}