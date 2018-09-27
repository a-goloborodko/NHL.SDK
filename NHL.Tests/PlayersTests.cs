using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHL.Core.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NHL.Tests
{
    [TestClass]
    public class PlayersTests: BaseNHLTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "request must include a valid person Id")]
        public async Task GetPlayers()
        {
            var playersRequest = Client.GetPlayer();
            var players = await playersRequest.ExecuteAsync();
        }

        [TestMethod]
        public async Task GetPlayerById()
        {
            var playersRequest = Client.GetPlayer();
            playersRequest.SetId(8471675);
            var players = await playersRequest.ExecuteAsync();

            bool hasResponce = players.SafeAny();

            Assert.IsTrue(hasResponce);

            if (!hasResponce)
            {
                Assert.Fail("empty player responce");
                return;
            }

            Assert.AreEqual(players.Count, 1);

            var playerCompare = players.First();


            Assert.AreEqual(playerCompare.FirstName, "Sidney");
            Assert.AreEqual(playerCompare.LastName, "Crosby");
            Assert.AreEqual(playerCompare.Id, 8471675);
        }
    }
}
