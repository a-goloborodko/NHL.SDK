using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHL.Core.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace NHL.Tests
{
    [TestClass]
    public class FranchisesTests : BaseNHLTest
    {
        [TestMethod]
        public async Task GetFranchises()
        {
            var conferences = await Client.GetFranchises().ExecuteAsync();

            Assert.IsTrue(conferences.SafeAny());
            Assert.AreEqual(conferences.Count, 38);
        }

        [TestMethod]
        public async Task GetFranchiseById()
        {
            var franchiseRequest = Client.GetFranchises();
            franchiseRequest.SetId(1);

            var franchises = await franchiseRequest.ExecuteAsync();

            bool hasResponce = franchises.SafeAny();

            Assert.IsTrue(hasResponce);

            if (!hasResponce)
            {
                Assert.Fail("empty franchise responce");
                return;
            }

            Assert.AreEqual(franchises.Count, 1);

            var franchiseToCompare = franchises.First();

            Assert.AreEqual(franchiseToCompare.Id, 1);
            Assert.AreEqual(franchiseToCompare.FirstSeasonId, Data.Enums.SeasonEnum._19171918);
            Assert.AreEqual(franchiseToCompare.LocationName, "Montréal");
            Assert.AreEqual(franchiseToCompare.MostRecentTeamId, 8);
            Assert.AreEqual(franchiseToCompare.TeamName, "Canadiens");
        }
    }
}