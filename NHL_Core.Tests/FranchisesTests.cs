using NHL.Data.Enums;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NHL_Core.Tests
{
    public class FranchisesTests : BaseNHLTest
    {
        [Fact]
        public async Task GetFranchisesOrderedById()
        {
            var franchises = await Client
                .GetFranchises()
                .OrderBy(x => x.Id)
                .ExecuteAsync();

            Assert.True(franchises.Success);
            Assert.NotEmpty(franchises.Data);

            var firstFranchise = franchises.Data.First();

            Assert.Equal("Montréal Canadiens", firstFranchise.FullName);
            Assert.Equal(1, firstFranchise.Id);
        }

        [Fact]
        public async Task GetFranchisesOrderedByDescendingById()
        {
            var franchises = await Client
                .GetFranchises()
                .OrderByDescending(x => x.Id)
                .ExecuteAsync();

            Assert.True(franchises.Success);
            Assert.NotEmpty(franchises.Data);

            var firstFranchise = franchises.Data.First();

            Assert.Equal("Vegas Golden Knights", firstFranchise.FullName);
            Assert.Equal(38, firstFranchise.Id);
        }

        [Fact]
        public async Task GetFranchisesWithoutSeasonIdData()
        {
            var franchises = await Client
               .GetFranchises()
               .OrderBy(x => x.Id)
               .ExecuteAsync();

            Assert.True(franchises.Success);
            Assert.NotEmpty(franchises.Data);

            var montrealWanderers = franchises.Data.Skip(1).First();

            Assert.Equal("Montreal Wanderers", montrealWanderers.FullName);
            Assert.Equal(2, montrealWanderers.Id);

            Assert.Null(montrealWanderers.FirstSeason);
            Assert.Null(montrealWanderers.LastSeason);
        }

        [Fact]
        public async Task GetFranchisesIncludeSeasonIdData()
        {
            var franchises = await Client
               .GetFranchises()
               .Include(x => x.FirstSeasonId)
               .Include(x => x.LastSeasonId)
               .OrderBy(x => x.Id)
               .ExecuteAsync();

            Assert.True(franchises.Success);
            Assert.NotEmpty(franchises.Data);

            var montrealWanderers = franchises.Data.Skip(1).First();

            Assert.Equal("Montreal Wanderers", montrealWanderers.FullName);
            Assert.Equal(2, montrealWanderers.Id);

            Assert.NotNull(montrealWanderers.FirstSeason);
            Assert.NotNull(montrealWanderers.LastSeason);

            Assert.Equal(SeasonEnum._19171918, montrealWanderers.FirstSeason.Id);
            Assert.Equal(SeasonEnum._19171918, montrealWanderers.LastSeason.Id);
        }
    }
}