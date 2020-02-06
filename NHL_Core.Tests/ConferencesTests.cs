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

            Assert.True(conferences.IsSuccess);
            Assert.True(conferences.Results.SafeAny());
            Assert.Equal(2, conferences.Results.Count);
        }

        [Fact]
        public async Task GetConferenceById()
        {
            var conferenceRequest = Client.GetConferences();

            conferenceRequest.SetId(6);

            var conferences = await conferenceRequest.ExecuteAsync();

            bool hasResponce = conferences.Results.SafeAny();
            Assert.True(conferences.IsSuccess);
            Assert.True(hasResponce);

            if (!hasResponce)
            {
                Assert.True(false, "empty conference responce");
                return;
            }

            Assert.Single(conferences.Results);

            var conferenceToCompare = conferences.Results.First();

            Assert.Equal("E", conferenceToCompare.Abbreviation);
            Assert.Equal("Eastern", conferenceToCompare.Name);
            Assert.Equal(6, conferenceToCompare.Id);
            Assert.Equal("East", conferenceToCompare.ShortName);
        }
    }
}
