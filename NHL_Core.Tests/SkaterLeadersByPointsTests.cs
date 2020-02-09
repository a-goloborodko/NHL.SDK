using NHL.Data.Enums;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NHL_Core.Tests
{
    public class SkaterLeadersByPointsTests: BaseNHLTest
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
    }
}
