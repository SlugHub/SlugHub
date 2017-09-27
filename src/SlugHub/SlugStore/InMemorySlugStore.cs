using System.Collections.Concurrent;

namespace SlugHub.SlugStore
{
    public class InMemorySlugStore : ISlugStore
    {
        internal static ConcurrentDictionary<string, Slug> Cache = new ConcurrentDictionary<string, Slug>();

        public bool Exists(string slug)
        {
            return Cache.ContainsKey(slug);
        }

        public void Store(Slug slug)
        {
            Cache.TryAdd(slug.Value, slug);
        }
    }
}