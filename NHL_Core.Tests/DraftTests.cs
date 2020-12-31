using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NHL_Core.Tests
{
    public class DraftTests: BaseNHLTest
    {
        [Fact]
        public async Task GetDraftsOrderedByDraftYear()
        {
            var drafts = await Client
              .GetDrafts()
              .OrderBy(x => x.DraftYear)
              .ExecuteAsync();

            Assert.True(drafts.Success);
            Assert.NotEmpty(drafts.Data);

            var firstDraft = drafts.Data.First();

            Assert.Equal(1963, firstDraft.DraftYear);
            Assert.Equal(49, firstDraft.Id);
            Assert.Equal(4, firstDraft.Rounds);
        }

        [Fact]
        public async Task GetDraftsOrderedById()
        {
            var drafts = await Client
              .GetDrafts()
              .OrderBy(x => x.Id)
              .ExecuteAsync();

            Assert.True(drafts.Success);
            Assert.NotEmpty(drafts.Data);

            var firstDraft = drafts.Data.First();

            Assert.Equal(1989, firstDraft.DraftYear);
            Assert.Equal(1, firstDraft.Id);
            Assert.Equal(12, firstDraft.Rounds);
        }
    }
}
