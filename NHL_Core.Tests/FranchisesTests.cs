using NHL.Data.Enums;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NHL_Core.Tests
{
    public class FranchisesTests : BaseNHLTest
    {
        [Fact]
        public async Task GetFranchises()
        {
            var conferences = await Client.GetFranchises().ExecuteAsync();

            Assert.True(conferences.IsSuccess);
            Assert.NotEmpty(conferences.Results);
            Assert.Equal(38, conferences.Results.Count);
        }

        [Fact]
        public async Task GetFranchiseById()
        {
            var franchiseRequest = Client.GetFranchises();
            franchiseRequest.Id = 1;

            var franchises = await franchiseRequest.ExecuteAsync();

            Assert.True(franchises.IsSuccess);
            Assert.NotEmpty(franchises.Results);

            Assert.Single(franchises.Results);

            var franchiseToCompare = franchises.Results.First();

            Assert.Equal(1, franchiseToCompare.Id);
            Assert.Equal(SeasonEnum._19171918, franchiseToCompare.FirstSeasonId);
            Assert.Equal("Montréal", franchiseToCompare.LocationName);
            Assert.Equal(8, franchiseToCompare.MostRecentTeamId);
            Assert.Equal("Canadiens", franchiseToCompare.TeamName);
        }
    }
}
