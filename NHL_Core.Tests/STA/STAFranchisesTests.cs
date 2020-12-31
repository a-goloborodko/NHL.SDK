using NHL.Data.Enums;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NHL_Core.Tests
{
    public class STAFranchisesTests : BaseNHLTest
    {
        [Fact]
        public async Task GetSTAFranchises()
        {
            var conferences = await Client.GetSTAFranchises().ExecuteAsync();

            Assert.True(conferences.Success);
            Assert.NotEmpty(conferences.Data);
            Assert.Equal(38, conferences.Data.Count);
        }

        [Fact]
        public async Task GetSTAFranchiseById()
        {
            var franchiseRequest = Client.GetSTAFranchises();
            franchiseRequest.SetId(1);

            var franchises = await franchiseRequest.ExecuteAsync();

            Assert.True(franchises.Success);
            Assert.NotEmpty(franchises.Data);

            Assert.Single(franchises.Data);

            var franchiseToCompare = franchises.Data.First();

            Assert.Equal(1, franchiseToCompare.Id);
            Assert.Equal(SeasonEnum._19171918, franchiseToCompare.FirstSeasonId);
            Assert.Equal("Montréal", franchiseToCompare.LocationName);
            Assert.Equal(8, franchiseToCompare.MostRecentTeamId);
            Assert.Equal("Canadiens", franchiseToCompare.TeamName);
        }
    }
}
