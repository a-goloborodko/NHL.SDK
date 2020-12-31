using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NHL_Core.Tests
{
    public class CountiresTests : BaseNHLTest
    {
        [Fact]
        public async Task GetCountries()
        {
            var countriesRequest = Client.GetCountries();
            var countries = await countriesRequest.ExecuteAsync();

            Assert.True(countries.Success);
            Assert.NotEmpty(countries.Data);
        }

        [Fact]
        public async Task GetCountriesOrderedByCountryName()
        {
            var countriesRequest = Client.GetCountries();

            var countries = await countriesRequest
                .OrderBy(x => x.CountryName)
                .ExecuteAsync();

            var firstCountry = countries.Data.FirstOrDefault();

            Assert.True(countries.Success);
            Assert.NotEmpty(countries.Data);
            Assert.Equal("AUS", firstCountry.Country3Code);
            Assert.Equal("Australia", firstCountry.CountryName);
            Assert.Equal("Australian", firstCountry.NationalityName);
        }

        [Fact]
        public async Task GetCountriesOrderedByDescendingByCountryName()
        {
            var countriesRequest = Client.GetCountries();
            var countries = await countriesRequest.OrderByDescending(x => x.CountryName).ExecuteAsync();
            var firstCountry = countries.Data.FirstOrDefault();

            Assert.True(countries.Success);
            Assert.NotEmpty(countries.Data);
            Assert.Equal("YUG", firstCountry.Country3Code);
            Assert.Equal("Yugoslavia", firstCountry.CountryName);
            Assert.Equal("Yugoslavian", firstCountry.NationalityName);
        }
    }
}