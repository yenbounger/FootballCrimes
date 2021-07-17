using FootballData.Client;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace FootballDataClientTests
{
    public class DataClientTests
    {
        // Didn't want to spend the time mocking HTTP Client
        private readonly FootballDataClient _footballDataClient = new(null, null);

        [Test]
        [TestCase(2017)]
        [TestCase(2021)]
        [TestCase(0)]
        public void ShouldNotAllowInvalidYears(int year)
        {
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _footballDataClient.GetTeamDataAsync(year));
            Assert.That(ex.Message == $"Must be a date between the current year, and the year 2000. Provided: {year}");
        }

        [Test]        
        public void ShouldAllowValidYears([Range(2018, 2020, 1)]  int year)
        {
            // As I am just testing validation here, a null ref exception asserts that it passes the validatation
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await _footballDataClient.GetTeamDataAsync(year));
        }
    }
}