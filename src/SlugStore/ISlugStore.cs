using System.Threading.Tasks;

namespace SlugHub.SlugStore
{
    public interface ISlugStore
    {
        Task<bool> Exists(string slug, string groupingKey);

        Task Store(Slug slug);
    }
}