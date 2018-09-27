using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHL.Core.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace NHL.Tests
{
    [TestClass]
    public class ConferencesTests : BaseNHLTest
    {
        [TestMethod]
        public async Task GetConferences()
        {
            var conferences = await Client.GetConferences().ExecuteAsync();

            Assert.IsTrue(conferences.SafeAny());
            Assert.AreEqual(conferences.Count, 2);
        }

        [TestMethod]
        public async Task GetConferenceById()
        {
            var conferenceRequest = Client.GetConferences();
            conferenceRequest.SetId(6);

            var conferences = await conferenceRequest.ExecuteAsync();

            bool hasResponce = conferences.SafeAny();

            Assert.IsTrue(hasResponce);

            if (!hasResponce)
            {
                Assert.Fail("empty conference responce");
                return;
            }

            Assert.AreEqual(conferences.Count, 1);

            var conferenceToCompare = conferences.First();

            Assert.AreEqual(conferenceToCompare.Abbreviation, "E");
            Assert.AreEqual(conferenceToCompare.Name, "Eastern");
            Assert.AreEqual(conferenceToCompare.Id, 6);
            Assert.AreEqual(conferenceToCompare.ShortName, "East");
        }
    }
}
