using FootballCrimes.API.Extensions;
using FootballCrimes.API.Models.Enums;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballCrimes.API.Tests.ExtensionTests
{
    public class ToCrimeTypeTests
    {
        [Test]
        public void ShouldThrowOnInvalidString()
        {
            // NUnit randomizer doesn't include '-', so there is 0 chance of getting a false positive
            var testString = Randomizer.CreateRandomizer().GetString();
            var ex = Assert.Throws<ArgumentException>(() => testString.ToCrimeType());
            Assert.That(ex.Message == $"Crime type currently not supported. Provided: {testString}");
        }

        [Test]
        [TestCase("anti-social-behaviour", CrimeType.AntiSocialBehaviour)]
        [TestCase("drugs", CrimeType.Drugs)]
        [TestCase("theft-from-the-person", CrimeType.TheftFromThePerson)]
        public void ShouldParseCorrectCrimeTypes(string testString, CrimeType expectedCrime)
        {
            Assert.That(testString.ToCrimeType() == expectedCrime);
        }
    }
}
