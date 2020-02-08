using NHL.Core.Extensions;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NHL_Core.Tests
{
    public class ConferencesTests : BaseNHLTest
    {
        [Fact]
        public async Task GetConferences()
        {
            var conferences = await Client.GetConferences().ExecuteAsync();

            Assert.True(conferences.Success);
            Assert.True(conferences.Data.SafeAny());
            Assert.Equal(2, conferences.Data.Count);
        }

        [Fact]
        public async Task GetConferenceById()
        {
            var conferenceRequest = Client.GetConferences();

            conferenceRequest.SetId(6);

            var conferences = await conferenceRequest.ExecuteAsync();

            bool hasResponce = conferences.Data.SafeAny();
            Assert.True(conferences.Success);
            Assert.True(hasResponce);

            if (!hasResponce)
            {
                Assert.True(false, "empty conference responce");
                return;
            }

            Assert.Single(conferences.Data);

            var conferenceToCompare = conferences.Data.First();

            Assert.Equal("E", conferenceToCompare.Abbreviation);
            Assert.Equal("Eastern", conferenceToCompare.Name);
            Assert.Equal(6, conferenceToCompare.Id);
            Assert.Equal("East", conferenceToCompare.ShortName);
        }
    }
}
