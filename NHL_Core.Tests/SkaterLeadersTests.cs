using NHL.Data.Enums;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NHL_Core.Tests
{
    public class SkaterLeadersTests : BaseNHLTest
    {
        [Fact]
        public async Task GetSkaterLeadersByPoints()
        {
            var skaterLeadersByPoints = await Client.GetSkaterLeadersByPoints()
                .SetSeasonId(SeasonEnum._20132014)
                .SetGameType(GameTypeEnum.RegularSeason)
                .ExecuteAsync();

            Assert.True(skaterLeadersByPoints.Success);
            Assert.NotEmpty(skaterLeadersByPoints.Data);

            var firstLeader = skaterLeadersByPoints.Data.First();

            Assert.NotNull(firstLeader.Player);
            Assert.NotNull(firstLeader.Team);
            Assert.Equal(104, firstLeader.Points);
            Assert.Equal(8471675, firstLeader.Player.Id);
            Assert.Equal("Sidney Crosby", firstLeader.Player.FullName);
            Assert.Equal(5, firstLeader.Team.Id);
        }

        [Fact]
        public async Task GetPlayoffSkaterLeadersByPoints()
        {
            var skaterLeadersByPoints = await Client.GetSkaterLeadersByPoints()
               .SetSeasonId(SeasonEnum._20162017)
               .SetGameType(GameTypeEnum.PlayOff)
               .ExecuteAsync();

            Assert.True(skaterLeadersByPoints.Success);
            Assert.NotEmpty(skaterLeadersByPoints.Data);

            var firstLeader = skaterLeadersByPoints.Data.First();

            Assert.NotNull(firstLeader.Player);
            Assert.NotNull(firstLeader.Team);
            Assert.Equal(28, firstLeader.Points);
            Assert.Equal(8471215, firstLeader.Player.Id);
            Assert.Equal("Evgeni Malkin", firstLeader.Player.FullName);
            Assert.Equal(5, firstLeader.Team.Id);
        }

        [Fact]
        public async Task GetSkaterLeadersByGoals()
        {
            var skaterLeadersByPoints = await Client.GetSkaterLeadersByGoals()
               .SetSeasonId(SeasonEnum._20162017)
               .SetGameType(GameTypeEnum.RegularSeason)
               .ExecuteAsync();

            Assert.True(skaterLeadersByPoints.Success);
            Assert.NotEmpty(skaterLeadersByPoints.Data);

            var firstLeader = skaterLeadersByPoints.Data.First();

            Assert.NotNull(firstLeader.Player);
            Assert.NotNull(firstLeader.Team);
            Assert.Equal(44, firstLeader.Goals);
            Assert.Equal(8471675, firstLeader.Player.Id);
            Assert.Equal("Sidney Crosby", firstLeader.Player.FullName);
            Assert.Equal(5, firstLeader.Team.Id);
        }

        [Fact]
        public async Task GetPlayoffSkaterLeadersByGoals()
        {
            var skaterLeadersByGoals = await Client.GetSkaterLeadersByGoals()
               .SetSeasonId(SeasonEnum._20162017)
               .SetGameType(GameTypeEnum.PlayOff)
               .ExecuteAsync();

            Assert.True(skaterLeadersByGoals.Success);
            Assert.NotEmpty(skaterLeadersByGoals.Data);

            var firstLeader = skaterLeadersByGoals.Data.First();

            Assert.NotNull(firstLeader.Player);
            Assert.NotNull(firstLeader.Team);
            Assert.Equal(13, firstLeader.Goals);
            Assert.Equal(8477404, firstLeader.Player.Id);
            Assert.Equal("Jake Guentzel", firstLeader.Player.FullName);
            Assert.Equal(5, firstLeader.Team.Id);
        }

        [Fact]
        public async Task GetSkaterLeadersByAssists()
        {
            var skaterLeadersByAssists = await Client.GetSkaterLeadersByAssists()
               .SetSeasonId(SeasonEnum._20132014)
               .SetGameType(GameTypeEnum.RegularSeason)
               .ExecuteAsync();

            Assert.True(skaterLeadersByAssists.Success);
            Assert.NotEmpty(skaterLeadersByAssists.Data);

            var firstLeader = skaterLeadersByAssists.Data.First();

            Assert.NotNull(firstLeader.Player);
            Assert.NotNull(firstLeader.Team);
            Assert.Equal(68, firstLeader.Assists);
            Assert.Equal(8471675, firstLeader.Player.Id);
            Assert.Equal("Sidney Crosby", firstLeader.Player.FullName);
            Assert.Equal(5, firstLeader.Team.Id);
        }

        [Fact]
        public async Task GetPlaypffSkaterLeadersByAssists()
        {
            var skaterLeadersByAssists = await Client.GetSkaterLeadersByAssists()
               .SetSeasonId(SeasonEnum._20132014)
               .SetGameType(GameTypeEnum.PlayOff)
               .ExecuteAsync();

            Assert.True(skaterLeadersByAssists.Success);
            Assert.NotEmpty(skaterLeadersByAssists.Data);

            var firstLeader = skaterLeadersByAssists.Data.First();

            Assert.NotNull(firstLeader.Player);
            Assert.NotNull(firstLeader.Team);
            Assert.Equal(21, firstLeader.Assists);
            Assert.Equal(8471685, firstLeader.Player.Id);
            Assert.Equal("Anze Kopitar", firstLeader.Player.FullName);
            Assert.Equal(26, firstLeader.Team.Id);
        }
    }
}
