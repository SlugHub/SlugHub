using NUnit.Framework;
using SlugFarm.SlugStore;

namespace SlugFarm.Tests.SlugStore
{
    [TestFixture]
    public class InMemorySlugStoreTests
    {
        private InMemorySlugStore _inMemorySlugStore;

        [SetUp]
        public void BeforeEachTest()
        {
            _inMemorySlugStore = new InMemorySlugStore();
        }

        [Test]
        public void Store_Adds_slug_value_to_collection()
        {
            _inMemorySlugStore.Store(new Slug("Store_Adds_slug_value_to_collection"));

            var result = _inMemorySlugStore.Exists("Store_Adds_slug_value_to_collection");

            Assert.That(result, Is.True);
        }

        [Test]
        public void Exists_Returns_true_if_slug_value_exists()
        {
            _inMemorySlugStore.Store(new Slug("Exists_Returns_true_if_slug_value_exists"));

            var result = _inMemorySlugStore.Exists("Exists_Returns_true_if_slug_value_exists");

            Assert.That(result, Is.True);
        }


        [Test]
        public void Exists_Returns_false_if_slug_value_does_not_exist()
        {
            var result = _inMemorySlugStore.Exists("Exists_Returns_false_if_slug_value_does_not_exist");

            Assert.That(result, Is.False);
        }
    }
}
