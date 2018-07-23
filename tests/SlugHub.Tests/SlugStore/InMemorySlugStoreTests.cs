﻿using NUnit.Framework;
using SlugHub.SlugStore;

namespace SlugHub.Tests.SlugStore
{
    [TestFixture]
    public class InMemorySlugStoreTests
    {
        private InMemorySlugStore _inMemorySlugStore;

        [SetUp]
        public void BeforeEachTest()
        {
            _inMemorySlugStore = new InMemorySlugStore();
            _inMemorySlugStore.Clear();
        }

        public class WithGroupingKey : InMemorySlugStoreTests
        {
            [Test]
            public void Store_Adds_slug_value_to_collection()
            {
                _inMemorySlugStore.Store(new Slug("Store_Adds_slug_value_to_collection", "group1"));

                var result = _inMemorySlugStore.Exists("Store_Adds_slug_value_to_collection", "group1");

                Assert.That(result, Is.True);
            }

            [Test]
            public void Exists_Returns_true_if_slug_value_exists_in_same_group()
            {
                _inMemorySlugStore.Store(new Slug("Exists_Returns_true_if_slug_value_exists", "group1"));

                var result = _inMemorySlugStore.Exists("Exists_Returns_true_if_slug_value_exists", "group1");

                Assert.That(result, Is.True);
            }

            [Test]
            public void Exists_Returns_false_if_slug_value_exists_but_in_different_group()
            {
                _inMemorySlugStore.Store(new Slug("Exists_Returns_true_if_slug_value_exists", "group1"));

                var result = _inMemorySlugStore.Exists("Exists_Returns_true_if_slug_value_exists", "group2");

                Assert.That(result, Is.False);
            }

            [Test]
            public void Exists_Returns_false_if_slug_value_does_not_exist()
            {
                var result = _inMemorySlugStore.Exists("Exists_Returns_false_if_slug_value_does_not_exist", "group1");
                Assert.That(result, Is.False);
            }

            [Test]
            public void Exists_Returns_false_if_group_does_not_exist()
            {
                _inMemorySlugStore.Store(new Slug("Exists_Returns_true_if_slug_value_exists", "group1"));

                var result = _inMemorySlugStore.Exists("Exists_Returns_true_if_slug_value_exists", "NOT_EXIST");

                Assert.That(result, Is.False);
            }
        }

        public class WithNullGroupingKey : InMemorySlugStoreTests
        {
            [Test]
            public void Store_Adds_slug_value_to_collection()
            {
                _inMemorySlugStore.Store(new Slug("Store_Adds_slug_value_to_collection", null));

                var result = _inMemorySlugStore.Exists("Store_Adds_slug_value_to_collection", null);

                Assert.That(result, Is.True);
            }

            [Test]
            public void Exists_Returns_true_if_slug_value_exists()
            {
                _inMemorySlugStore.Store(new Slug("Exists_Returns_true_if_slug_value_exists", null));

                var result = _inMemorySlugStore.Exists("Exists_Returns_true_if_slug_value_exists", null);

                Assert.That(result, Is.True);
            }

            [Test]
            public void Exists_Returns_false_if_slug_value_does_not_exist()
            {
                var result = _inMemorySlugStore.Exists("Exists_Returns_false_if_slug_value_does_not_exist", null);
                Assert.That(result, Is.False);
            }
        }

        public class WithStringEmptyGroupingKey : InMemorySlugStoreTests
        {
            [Test]
            public void Store_Adds_slug_value_to_collection()
            {
                _inMemorySlugStore.Store(new Slug("Store_Adds_slug_value_to_collection", string.Empty));

                var result = _inMemorySlugStore.Exists("Store_Adds_slug_value_to_collection", string.Empty);

                Assert.That(result, Is.True);
            }

            [Test]
            public void Exists_Returns_true_if_slug_value_exists()
            {
                _inMemorySlugStore.Store(new Slug("Exists_Returns_true_if_slug_value_exists", string.Empty));

                var result = _inMemorySlugStore.Exists("Exists_Returns_true_if_slug_value_exists", string.Empty);

                Assert.That(result, Is.True);
            }

            [Test]
            public void Exists_Returns_false_if_slug_value_does_not_exist()
            {
                var result = _inMemorySlugStore.Exists("Exists_Returns_false_if_slug_value_does_not_exist", string.Empty);
                Assert.That(result, Is.False);
            }
        }
    }
}
