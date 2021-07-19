using FootballCrimes.API.Config;
using FootballData.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace FootballDataClientTests
{
    public class DataClientTests
    {
        // Didn't want to spend the time mocking HTTP Client
        private FootballDataClient _footballDataClient;


        [SetUp]
        public void Setup()
        {
            var apiKeys = new ApiKeys { FootballData = "notAKey" };
            _footballDataClient = new FootballDataClient(null, Options.Create<ApiKeys>(apiKeys));
        }
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