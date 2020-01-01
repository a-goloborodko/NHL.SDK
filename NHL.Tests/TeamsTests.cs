//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NHL.Client;
//using NHL.Core.Extensions;
//using System;
//using System.Linq;
//using System.Threading.Tasks;

//namespace NHL.Tests
//{
//    [TestClass]
//    public class TeamsTests: BaseNHLTest
//    {
//        [TestMethod]
//        public async Task GetTeams()
//        {
//            var teamsRequest = Client.GetTeams();
//            var teams = await teamsRequest.ExecuteAsync();

//            Assert.IsTrue(teams.SafeAny());
//            Assert.AreEqual(teams.Count, 31);

//            var teamToCompare = teams.FirstOrDefault(team => team.Abbreviation.Equals("PIT", StringComparison.OrdinalIgnoreCase));

//            if (teamToCompare == null)
//            {
//                Assert.Fail();
//                return;
//            }


//            Assert.AreEqual(teamToCompare.Abbreviation, "PIT");
//            Assert.AreEqual(teamToCompare.Name, "Pittsburgh Penguins");
//            Assert.AreEqual(teamToCompare.Id, 5);
//            Assert.AreEqual(teamToCompare.Conference.Id, 6);
//            Assert.AreEqual(teamToCompare.Division.Id, 18);
//            Assert.AreEqual(teamToCompare.Franchise.Id, 17);
//        }

//        [TestMethod]
//        public async Task GetTeamById()
//        {
//            var teamsRequest = Client.GetTeams();
//            teamsRequest.SetId(5);

//            var teams = await teamsRequest.ExecuteAsync();

//            Assert.IsTrue(teams.SafeAny());
//            Assert.AreEqual(teams.Count, 1);

//            var teamToCompare = teams.First();

//            Assert.AreEqual(teamToCompare.Abbreviation, "PIT");
//            Assert.AreEqual(teamToCompare.Name, "Pittsburgh Penguins");
//            Assert.AreEqual(teamToCompare.Id, 5);
//            Assert.AreEqual(teamToCompare.Conference.Id, 6);
//            Assert.AreEqual(teamToCompare.Division.Id, 18);
//            Assert.AreEqual(teamToCompare.Franchise.Id, 17);
//        }
//    }
//}
