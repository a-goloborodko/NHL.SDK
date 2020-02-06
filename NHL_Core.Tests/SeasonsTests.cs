using NHL.Data.Enums;
using NHL.Data.Helpers;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NHL_Core.Tests
{
    public class SeasonsTests: BaseNHLTest
    {
        [Fact]
        public async Task GetAllSeasons()
        {
            var seasons = await Client.GetSeasons().ExecuteAsync();

            Assert.True(seasons.IsSuccess);
            Assert.NotEmpty(seasons.Data);

            var firstSeason = seasons.Data.First();

            Assert.Equal(SeasonEnum._19171918, firstSeason.Id);
            Assert.Equal(22, firstSeason.NumberOfGames);
            Assert.Equal(7, firstSeason.TotalPlayoffGames);
            Assert.Equal(6, firstSeason.MinimumRegularGamesForGoalieStatsLeaders);
            Assert.Equal(50, firstSeason.MinimumPlayoffMinutesForGoalieStatsLeaders);
            Assert.Equal("1917-18", firstSeason.FormattedSeasonId);
        }

        [Fact]
        public async Task GetCurrentSeason()
        {
            var currentSeasonResponse = await Client.GetCurrentSeasonSeason().ExecuteAsync();

            Assert.True(currentSeasonResponse.IsSuccess);
            Assert.Single(currentSeasonResponse.Data);

            var currentSeason = currentSeasonResponse.Data.Single();
            var currentSeasonFromSeasonHelper = SeasonHelper.GetCurrectSeason();

            Assert.Equal(currentSeasonFromSeasonHelper, currentSeason.Id);
        }
    }
}