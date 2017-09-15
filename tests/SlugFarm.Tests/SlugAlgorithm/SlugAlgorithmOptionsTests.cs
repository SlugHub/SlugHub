using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using SlugFarm.SlugAlgorithm;

namespace SlugFarm.Tests.SlugAlgorithm
{
    [TestFixture]
    public class SlugAlgorithmOptionsTests
    {
        [Test]
        public void can_add_manipulators_to_options_Ctor()
        {
            var slugAlgorithmOptions = new SlugAlgorithmOptions(
                str => Regex.Replace(str, @"[^a-z0-9\s-]", ""),
                str => str.ToLower());

            Assert.That(slugAlgorithmOptions.Manipulators.Count, Is.EqualTo(2));
        }
    }
}