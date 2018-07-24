using System.Collections.Concurrent;
using System.Threading.Tasks;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("SlugHub.Tests")]

namespace SlugHub.SlugStore
{
    public class InMemorySlugStore : ISlugStore
    {
        private const string DefaultCacheGroupingKey = "Default";

        private static readonly ConcurrentDictionary<string, ConcurrentDictionary<string, Slug>> GroupedCache;

        static InMemorySlugStore()
        {
            GroupedCache = new ConcurrentDictionary<string, ConcurrentDictionary<string, Slug>>();

            if (!GroupedCache.ContainsKey(DefaultCacheGroupingKey))
            {
                GroupedCache.TryAdd(DefaultCacheGroupingKey, new ConcurrentDictionary<string, Slug>());
            }
        }

        public Task<bool> Exists(string slug, string groupingKey)
        {
            if (string.IsNullOrEmpty(groupingKey))
                groupingKey = DefaultCacheGroupingKey;

            if (!GroupedCache.ContainsKey(groupingKey))
                return Task.FromResult(false);

            var cache = GroupedCache[groupingKey];
            var cacheContainsKey = cache.ContainsKey(slug);

            return Task.FromResult(cacheContainsKey);
        }

        public Task Store(Slug slug)
        {
            var groupingKey = string.IsNullOrEmpty(slug.GroupingKey)
                ? DefaultCacheGroupingKey
                : slug.GroupingKey;

            if (!GroupedCache.ContainsKey(groupingKey))
                GroupedCache.TryAdd(groupingKey, new ConcurrentDictionary<string, Slug>());

            var cache = GroupedCache[groupingKey];
            cache.TryAdd(slug.Value, slug);

            return Task.FromResult(0);
        }

        internal void Clear()
        {
            GroupedCache.Clear();
        }
    }
}