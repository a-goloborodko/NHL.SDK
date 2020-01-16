using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NHL_Core.Tests
{
    public class PlayersTests : BaseNHLTest
    {
        [Fact]
        public async Task GetPlayers()
        {
            var playersRequest = Client.GetPlayer();
            var players = await playersRequest.ExecuteAsync();

            Assert.Single(players.Errors);
            Assert.False(players.IsSuccess);
        }

        [Fact]
        public async Task GetPlayerById()
        {
            var playersRequest = Client.GetPlayer();
            playersRequest.Set.Id = 8471675;
            var players = await playersRequest.ExecuteAsync();

            Assert.True(players.IsSuccess);
            Assert.NotEmpty(players.Results);

            Assert.Single(players.Results);

            var playerCompare = players.Results.First();

            Assert.Equal("Sidney", playerCompare.FirstName);
            Assert.Equal("Crosby", playerCompare.LastName);
            Assert.Equal(8471675, playerCompare.Id);
        }
    }
}
