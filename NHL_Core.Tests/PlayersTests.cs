using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NHL_Core.Tests
{
    public class PlayersTests : BaseNHLTest
    {
        const int playerId = 8471675;

        [Fact]
        public async Task GetPlayers()
        {
            var playersRequest = Client.GetPlayer();
            var players = await playersRequest.ExecuteAsync();

            Assert.Single(players.Errors);
            Assert.False(players.Success);
        }

        [Fact]
        public async Task GetPlayerById()
        {
            var playersRequest = Client.GetPlayer();
            playersRequest.SetId(playerId);
            var players = await playersRequest.ExecuteAsync();

            Assert.True(players.Success);
            Assert.NotEmpty(players.Data);

            Assert.Single(players.Data);

            var playerCompare = players.Data.First();

            Assert.Equal("Sidney", playerCompare.FirstName);
            Assert.Equal("Crosby", playerCompare.LastName);
            Assert.Empty(playerCompare.Stats);
            Assert.Equal(8471675, playerCompare.Id);
        }

        [Fact]
        public async Task GetPlayerByIdWithYearByYearStatistic()
        {
            var playersRequest = Client.GetPlayer();

            var players = await playersRequest.Include(x => x.YearByYearStatistic)
                .SetId(playerId)
                .ExecuteAsync();

            Assert.True(players.Success);
            Assert.NotEmpty(players.Data);

            Assert.Single(players.Data);

            var playerCompare = players.Data.First();

            Assert.Equal("Sidney", playerCompare.FirstName);
            Assert.Equal("Crosby", playerCompare.LastName);
            Assert.Single(playerCompare.Stats);
            Assert.Equal(8471675, playerCompare.Id);

            var yearByYearStat = playerCompare.Stats.Single();

            Assert.Equal("yearByYear", yearByYearStat.Type.DisplayName);
            Assert.NotEmpty(yearByYearStat.Splits);

            var firstSplit = yearByYearStat.Splits.First();

            Assert.Equal("20012002", firstSplit.Season);
            Assert.Equal(98, firstSplit.Stat.Assists);
            Assert.Equal(95, firstSplit.Stat.Goals);
            Assert.Equal(74, firstSplit.Stat.Games);
            Assert.Equal("114", firstSplit.Stat.PenaltyMinutes);
            Assert.Equal(193, firstSplit.Stat.Points);
        }

        [Fact]
        public async Task GetPlayerByIdWithCareerRegularSeasonStatistic()
        {
            var playersRequest = Client.GetPlayer();

            var players = await playersRequest.Include(x => x.CareerRegularSeasonStatistic)
                .SetId(playerId)
                .ExecuteAsync();

            Assert.True(players.Success);
            Assert.NotEmpty(players.Data);

            Assert.Single(players.Data);

            var playerCompare = players.Data.First();

            Assert.Equal("Sidney", playerCompare.FirstName);
            Assert.Equal("Crosby", playerCompare.LastName);
            Assert.Single(playerCompare.Stats);
            Assert.Equal(8471675, playerCompare.Id);

            var careerRegularSeasonStat = playerCompare.Stats.Single();

            Assert.Equal("careerRegularSeason", careerRegularSeasonStat.Type.DisplayName);
            Assert.Single(careerRegularSeasonStat.Splits);
        }

        [Fact]
        public async Task GetPlayerByIdWithAllStatistics()
        {
            var playersRequest = Client.GetPlayer();

            var players = await playersRequest.Include(x => x.CareerRegularSeasonStatistic)
                .Include(x => x.YearByYearStatistic)
                .SetId(playerId)
                .ExecuteAsync();

            Assert.True(players.Success);
            Assert.NotEmpty(players.Data);

            Assert.Single(players.Data);

            var playerCompare = players.Data.First();

            Assert.Equal("Sidney", playerCompare.FirstName);
            Assert.Equal("Crosby", playerCompare.LastName);
            Assert.Equal(2, playerCompare.Stats.Count);
            Assert.Equal(8471675, playerCompare.Id);

            var yearByYearStat = playerCompare.Stats.First(x => x.Type.DisplayName == "yearByYear");
            var careerRegularSeasonStat = playerCompare.Stats.First(x => x.Type.DisplayName == "careerRegularSeason");

            //YearByYear
            Assert.NotNull(yearByYearStat);
            Assert.Equal("yearByYear", yearByYearStat.Type.DisplayName);
            Assert.NotEmpty(yearByYearStat.Splits);

            var firstSplit = yearByYearStat.Splits.First();

            Assert.Equal("20012002", firstSplit.Season);
            Assert.Equal(98, firstSplit.Stat.Assists);
            Assert.Equal(95, firstSplit.Stat.Goals);
            Assert.Equal(74, firstSplit.Stat.Games);
            Assert.Equal("114", firstSplit.Stat.PenaltyMinutes);
            Assert.Equal(193, firstSplit.Stat.Points);

            //CareerRegularSeason
            Assert.NotNull(careerRegularSeasonStat);
            Assert.Single(careerRegularSeasonStat.Splits);
        }
    }
}
