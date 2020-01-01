//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NHL.Core.Extensions;

//namespace NHL.Tests
//{
//    [TestClass]
//    public class LeadersTests : BaseNHLTest
//    {
//        [TestMethod]
//        public async Task GetLeaders_20172018_RegularSeason_Statistics()
//        {
//            var leadersRequest = Client.GetLeaders();

//            leadersRequest.SetGameType(Data.Enums.GameTypeEnum.RegularSeason);
//            leadersRequest.SetSeason(Data.Enums.SeasonEnum._20162017);

//            var leaders = await leadersRequest.ExecuteAsync();

//            Assert.IsTrue(leaders.Skater.SafeAny() && leaders.Goalie.SafeAny());

//            if (!leaders.Skater.SafeAny() || !leaders.Goalie.SafeAny())
//            {
//                Assert.Fail("empty leaders 20172018 regular season results");
//                return;
//            }

//            Assert.AreEqual(leaders.Goalie.Count, 4);
//            Assert.AreEqual(leaders.Skater.Count, 4);

//            //GOALIE
//            //

//            Assert.AreEqual(leaders.Goalie.First().Measure, "gaa");
//            Assert.AreEqual(leaders.Goalie.First().LeagueAverage, "2.59");
//            Assert.AreEqual(leaders.Goalie.First().Leaders.First().FirstName, "Sergei");
//            Assert.AreEqual(leaders.Goalie.First().Leaders.First().LastName, "Bobrovsky");
//            Assert.AreEqual(leaders.Goalie.First().Leaders.First().PlayerId, 8475683);
//            Assert.IsTrue(Math.Abs((leaders.Goalie.First().Leaders.First().Value - 2.055534) / leaders.Goalie[1].Leaders.First().Value * 100) < 0.0001);

//            Assert.AreEqual(leaders.Goalie[1].Measure, "savePercentage");
//            Assert.AreEqual(leaders.Goalie[1].LeagueAverage, ".914");
//            Assert.AreEqual(leaders.Goalie[1].Leaders.First().FirstName, "Sergei");
//            Assert.AreEqual(leaders.Goalie[1].Leaders.First().LastName, "Bobrovsky");
//            Assert.AreEqual(leaders.Goalie[1].Leaders.First().PlayerId, 8475683);
//            Assert.IsTrue(Math.Abs((leaders.Goalie[1].Leaders.First().Value - 0.931499) / leaders.Goalie[1].Leaders.First().Value * 100) < 0.0001);

//            Assert.AreEqual(leaders.Goalie[2].Measure, "wins");
//            Assert.AreEqual(leaders.Goalie[2].LeagueAverage, "12.9");
//            Assert.AreEqual(leaders.Goalie[2].Leaders.First().FirstName, "Braden");
//            Assert.AreEqual(leaders.Goalie[2].Leaders.First().LastName, "Holtby");
//            Assert.AreEqual(leaders.Goalie[2].Leaders.First().PlayerId, 8474651);
//            Assert.AreEqual(leaders.Goalie[2].Leaders.First().Value, 42);

//            Assert.AreEqual(leaders.Goalie[3].Measure, "shutout");
//            Assert.AreEqual(leaders.Goalie[3].LeagueAverage, "1.7");
//            Assert.AreEqual(leaders.Goalie[3].Leaders.First().FirstName, "Braden");
//            Assert.AreEqual(leaders.Goalie[3].Leaders.First().LastName, "Holtby");
//            Assert.AreEqual(leaders.Goalie[3].Leaders.First().PlayerId, 8474651);
//            Assert.AreEqual(leaders.Goalie[3].Leaders.First().Value, 9);

//            //SKATERS
//            //

//            Assert.AreEqual(leaders.Skater.First().Measure, "points");
//            Assert.AreEqual(leaders.Skater.First().LeagueAverage, "20.2");
//            Assert.AreEqual(leaders.Skater.First().Leaders.First().FirstName, "Connor");
//            Assert.AreEqual(leaders.Skater.First().Leaders.First().LastName, "McDavid");
//            Assert.AreEqual(leaders.Skater.First().Leaders.First().PlayerId, 8478402);
//            Assert.AreEqual(leaders.Skater.First().Leaders.First().Value, 100);

//            Assert.AreEqual(leaders.Skater[1].Measure, "goals");
//            Assert.AreEqual(leaders.Skater[1].LeagueAverage, "7.5");
//            Assert.AreEqual(leaders.Skater[1].Leaders.First().FirstName, "Sidney");
//            Assert.AreEqual(leaders.Skater[1].Leaders.First().LastName, "Crosby");
//            Assert.AreEqual(leaders.Skater[1].Leaders.First().PlayerId, 8471675);
//            Assert.AreEqual(leaders.Skater[1].Leaders.First().Value, 44);

//            Assert.AreEqual(leaders.Skater[2].Measure, "assists");
//            Assert.AreEqual(leaders.Skater[2].LeagueAverage, "12.7");
//            Assert.AreEqual(leaders.Skater[2].Leaders.First().FirstName, "Connor");
//            Assert.AreEqual(leaders.Skater[2].Leaders.First().LastName, "McDavid");
//            Assert.AreEqual(leaders.Skater[2].Leaders.First().PlayerId, 8478402);
//            Assert.AreEqual(leaders.Skater[2].Leaders.First().Value, 70);

//            Assert.AreEqual(leaders.Skater[3].Measure, "plusMinus");
//            Assert.AreEqual(leaders.Skater[3].LeagueAverage, "-0.4");
//            Assert.AreEqual(leaders.Skater[3].Leaders.First().FirstName, "Jason");
//            Assert.AreEqual(leaders.Skater[3].Leaders.First().LastName, "Zucker");
//            Assert.AreEqual(leaders.Skater[3].Leaders.First().PlayerId, 8475722);
//            Assert.AreEqual(leaders.Skater[3].Leaders.First().Value, 34);
//        }

//        [TestMethod]
//        public async Task GetLeaders_20172018_RegularSeason_Statistics_Not_Correct()
//        {
//            var leadersRequest = Client.GetLeaders();
//            leadersRequest.SetGameType(Data.Enums.GameTypeEnum.RegularSeason);
//            leadersRequest.SetSeason(Data.Enums.SeasonEnum._20162017);

//            var leaders = await leadersRequest.ExecuteAsync();

//            Assert.AreEqual(leaders.Goalie.First().Measure, "gaa");
//            Assert.AreEqual(leaders.Goalie.First().LeagueAverage, "2.59");
//            Assert.AreEqual(leaders.Goalie.First().Leaders.First().FirstName, "Sergei");
//            Assert.AreEqual(leaders.Goalie.First().Leaders.First().LastName, "Bobrovsky");
//            Assert.AreEqual(leaders.Goalie.First().Leaders.First().PlayerId, 8475683);

//            double correctVaue = 2.055534;
//            double incorrectValue = correctVaue * 0.998;

//            Assert.IsFalse(Math.Abs((leaders.Goalie.First().Leaders.First().Value - incorrectValue) / leaders.Goalie[1].Leaders.First().Value * 100) < 0.0001);
//        }

//        [TestMethod]
//        public async Task GetLeaders_20172018_PlayOff_Statistics()
//        {
//            var leadersRequest = Client.GetLeaders();

//            leadersRequest.SetGameType(Data.Enums.GameTypeEnum.PlayOff);
//            leadersRequest.SetSeason(Data.Enums.SeasonEnum._20162017);

//            var leaders = await leadersRequest.ExecuteAsync();

//            Assert.IsTrue(leaders.Skater.SafeAny() && leaders.Goalie.SafeAny());

//            if (!leaders.Skater.SafeAny() || !leaders.Goalie.SafeAny())
//            {
//                Assert.Fail("empty leaders 20172018 playoff season results");
//                return;
//            }

//            Assert.AreEqual(leaders.Goalie.Count, 4);
//            Assert.AreEqual(leaders.Skater.Count, 4);

//            //GOALIE
//            //

//            Assert.AreEqual(leaders.Goalie.First().Measure, "gaa");
//            Assert.AreEqual(leaders.Goalie.First().LeagueAverage, "2.36");
//            Assert.AreEqual(leaders.Goalie.First().Leaders.First().FirstName, "Matt");
//            Assert.AreEqual(leaders.Goalie.First().Leaders.First().LastName, "Murray");
//            Assert.AreEqual(leaders.Goalie.First().Leaders.First().PlayerId, 8476899);
//            Assert.IsTrue(Math.Abs((leaders.Goalie.First().Leaders.First().Value - 1.704248) / leaders.Goalie[1].Leaders.First().Value * 100) < 0.0001);

//            Assert.AreEqual(leaders.Goalie[1].Measure, "savePercentage");
//            Assert.AreEqual(leaders.Goalie[1].LeagueAverage, ".920");
//            Assert.AreEqual(leaders.Goalie[1].Leaders.First().FirstName, "Matt");
//            Assert.AreEqual(leaders.Goalie[1].Leaders.First().LastName, "Murray");
//            Assert.AreEqual(leaders.Goalie[1].Leaders.First().PlayerId, 8476899);
//            Assert.IsTrue(Math.Abs((leaders.Goalie[1].Leaders.First().Value - 0.937294) / leaders.Goalie[1].Leaders.First().Value * 100) < 0.0001);

//            Assert.AreEqual(leaders.Goalie[2].Measure, "wins");
//            Assert.AreEqual(leaders.Goalie[2].LeagueAverage, "3.8");
//            Assert.AreEqual(leaders.Goalie[2].Leaders.First().FirstName, "Pekka");
//            Assert.AreEqual(leaders.Goalie[2].Leaders.First().LastName, "Rinne");
//            Assert.AreEqual(leaders.Goalie[2].Leaders.First().PlayerId, 8471469);
//            Assert.AreEqual(leaders.Goalie[2].Leaders.First().Value, 14);

//            Assert.AreEqual(leaders.Goalie[3].Measure, "shutout");
//            Assert.AreEqual(leaders.Goalie[3].LeagueAverage, "0.6");
//            Assert.AreEqual(leaders.Goalie[3].Leaders.First().FirstName, "Matt");
//            Assert.AreEqual(leaders.Goalie[3].Leaders.First().LastName, "Murray");
//            Assert.AreEqual(leaders.Goalie[3].Leaders.First().PlayerId, 8476899);
//            Assert.AreEqual(leaders.Goalie[3].Leaders.First().Value, 3);

//            //SKATERS
//            //

//            Assert.AreEqual(leaders.Skater.First().Measure, "points");
//            Assert.AreEqual(leaders.Skater.First().LeagueAverage, "3.5");
//            Assert.AreEqual(leaders.Skater.First().Leaders.First().FirstName, "Evgeni");
//            Assert.AreEqual(leaders.Skater.First().Leaders.First().LastName, "Malkin");
//            Assert.AreEqual(leaders.Skater.First().Leaders.First().PlayerId, 8471215);
//            Assert.AreEqual(leaders.Skater.First().Leaders.First().Value, 28);

//            Assert.AreEqual(leaders.Skater[1].Measure, "goals");
//            Assert.AreEqual(leaders.Skater[1].LeagueAverage, "1.3");
//            Assert.AreEqual(leaders.Skater[1].Leaders.First().FirstName, "Jake");
//            Assert.AreEqual(leaders.Skater[1].Leaders.First().LastName, "Guentzel");
//            Assert.AreEqual(leaders.Skater[1].Leaders.First().PlayerId, 8477404);
//            Assert.AreEqual(leaders.Skater[1].Leaders.First().Value, 13);

//            Assert.AreEqual(leaders.Skater[2].Measure, "assists");
//            Assert.AreEqual(leaders.Skater[2].LeagueAverage, "2.2");
//            Assert.AreEqual(leaders.Skater[2].Leaders.First().FirstName, "Sidney");
//            Assert.AreEqual(leaders.Skater[2].Leaders.First().LastName, "Crosby");
//            Assert.AreEqual(leaders.Skater[2].Leaders.First().PlayerId, 8471675);
//            Assert.AreEqual(leaders.Skater[2].Leaders.First().Value, 19);

//            Assert.AreEqual(leaders.Skater[3].Measure, "plusMinus");
//            Assert.AreEqual(leaders.Skater[3].LeagueAverage, "-0.0");
//            Assert.AreEqual(leaders.Skater[3].Leaders.First().FirstName, "Filip");
//            Assert.AreEqual(leaders.Skater[3].Leaders.First().LastName, "Forsberg");
//            Assert.AreEqual(leaders.Skater[3].Leaders.First().PlayerId, 8476887);
//            Assert.AreEqual(leaders.Skater[3].Leaders.First().Value, 14);
//        }

//        [TestMethod]
//        public async Task GetLeaders_20172018_PlayOff_PIT_Statistics()
//        {
//            var leadersRequest = Client.GetLeaders();

//            leadersRequest.SetGameType(Data.Enums.GameTypeEnum.PlayOff);
//            leadersRequest.SetSeason(Data.Enums.SeasonEnum._20162017);
//            leadersRequest.SetTeam(Data.Enums.TeamEnum.PIT);

//            var leaders = await leadersRequest.ExecuteAsync();

//            Assert.IsTrue(leaders.Skater.SafeAny() && leaders.Goalie.SafeAny());

//            if (!leaders.Skater.SafeAny() || !leaders.Goalie.SafeAny())
//            {
//                Assert.Fail("empty leaders 20172018 playoff PIT season results");
//                return;
//            }

//            Assert.AreEqual(leaders.Goalie.Count, 4);
//            Assert.AreEqual(leaders.Skater.Count, 4);

//            //GOALIE
//            //

//            Assert.AreEqual(leaders.Goalie.First().Measure, "gaa");
//            Assert.AreEqual(leaders.Goalie.First().LeagueAverage, "2.36");
//            Assert.AreEqual(leaders.Goalie.First().Leaders.First().FirstName, "Matt");
//            Assert.AreEqual(leaders.Goalie.First().Leaders.First().LastName, "Murray");
//            Assert.AreEqual(leaders.Goalie.First().Leaders.First().PlayerId, 8476899);
//            Assert.IsTrue(Math.Abs((leaders.Goalie.First().Leaders.First().Value - 1.704248) / leaders.Goalie[1].Leaders.First().Value * 100) < 0.0001);

//            Assert.AreEqual(leaders.Goalie[1].Measure, "savePercentage");
//            Assert.AreEqual(leaders.Goalie[1].LeagueAverage, ".920");
//            Assert.AreEqual(leaders.Goalie[1].Leaders.First().FirstName, "Matt");
//            Assert.AreEqual(leaders.Goalie[1].Leaders.First().LastName, "Murray");
//            Assert.AreEqual(leaders.Goalie[1].Leaders.First().PlayerId, 8476899);
//            Assert.IsTrue(Math.Abs((leaders.Goalie[1].Leaders.First().Value - 0.937294) / leaders.Goalie[1].Leaders.First().Value * 100) < 0.0001);

//            Assert.AreEqual(leaders.Goalie[2].Measure, "wins");
//            Assert.AreEqual(leaders.Goalie[2].LeagueAverage, "3.8");
//            Assert.AreEqual(leaders.Goalie[2].Leaders.First().FirstName, "Marc-Andre");
//            Assert.AreEqual(leaders.Goalie[2].Leaders.First().LastName, "Fleury");
//            Assert.AreEqual(leaders.Goalie[2].Leaders.First().PlayerId, 8470594);
//            Assert.AreEqual(leaders.Goalie[2].Leaders.First().Value, 9);

//            Assert.AreEqual(leaders.Goalie[3].Measure, "shutout");
//            Assert.AreEqual(leaders.Goalie[3].LeagueAverage, "0.6");
//            Assert.AreEqual(leaders.Goalie[3].Leaders.First().FirstName, "Matt");
//            Assert.AreEqual(leaders.Goalie[3].Leaders.First().LastName, "Murray");
//            Assert.AreEqual(leaders.Goalie[3].Leaders.First().PlayerId, 8476899);
//            Assert.AreEqual(leaders.Goalie[3].Leaders.First().Value, 3);

//            //SKATERS
//            //

//            Assert.AreEqual(leaders.Skater.First().Measure, "points");
//            Assert.AreEqual(leaders.Skater.First().LeagueAverage, "3.5");
//            Assert.AreEqual(leaders.Skater.First().Leaders.First().FirstName, "Evgeni");
//            Assert.AreEqual(leaders.Skater.First().Leaders.First().LastName, "Malkin");
//            Assert.AreEqual(leaders.Skater.First().Leaders.First().PlayerId, 8471215);
//            Assert.AreEqual(leaders.Skater.First().Leaders.First().Value, 28);

//            Assert.AreEqual(leaders.Skater[1].Measure, "goals");
//            Assert.AreEqual(leaders.Skater[1].LeagueAverage, "1.3");
//            Assert.AreEqual(leaders.Skater[1].Leaders.First().FirstName, "Jake");
//            Assert.AreEqual(leaders.Skater[1].Leaders.First().LastName, "Guentzel");
//            Assert.AreEqual(leaders.Skater[1].Leaders.First().PlayerId, 8477404);
//            Assert.AreEqual(leaders.Skater[1].Leaders.First().Value, 13);

//            Assert.AreEqual(leaders.Skater[2].Measure, "assists");
//            Assert.AreEqual(leaders.Skater[2].LeagueAverage, "2.2");
//            Assert.AreEqual(leaders.Skater[2].Leaders.First().FirstName, "Sidney");
//            Assert.AreEqual(leaders.Skater[2].Leaders.First().LastName, "Crosby");
//            Assert.AreEqual(leaders.Skater[2].Leaders.First().PlayerId, 8471675);
//            Assert.AreEqual(leaders.Skater[2].Leaders.First().Value, 19);

//            Assert.AreEqual(leaders.Skater[3].Measure, "plusMinus");
//            Assert.AreEqual(leaders.Skater[3].LeagueAverage, "-0.0");
//            Assert.AreEqual(leaders.Skater[3].Leaders.First().FirstName, "Phil");
//            Assert.AreEqual(leaders.Skater[3].Leaders.First().LastName, "Kessel");
//            Assert.AreEqual(leaders.Skater[3].Leaders.First().PlayerId, 8473548);
//            Assert.AreEqual(leaders.Skater[3].Leaders.First().Value, 12);
//        }
//    }
//}
