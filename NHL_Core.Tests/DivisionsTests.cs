using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NHL_Core.Tests
{
    public class DivisionsTests : BaseNHLTest
    {
        [Fact]
        public async Task GetDivisions()
        {
            var divisions = await Client.GetDivisions().ExecuteAsync();

            Assert.True(divisions.IsSuccess);
            Assert.NotEmpty(divisions.Results);
            Assert.Equal(4, divisions.Results.Count);
        }

        [Fact]
        public async Task GetDivisionById()
        {
            var divisionRequest = Client.GetDivisions();
            divisionRequest.Set.Id = 17;

            var divisions = await divisionRequest.ExecuteAsync();

            Assert.True(divisions.IsSuccess);
            Assert.NotEmpty(divisions.Results);

            Assert.Single(divisions.Results);

            var divisionToCompare = divisions.Results.First();


            Assert.Equal("A", divisionToCompare.Abbreviation);
            Assert.Equal("Atlantic", divisionToCompare.Name);
            Assert.Equal(17, divisionToCompare.Id);
            Assert.Equal(6, divisionToCompare.Conference.Id);
        }
    }
}
