using Bunit;
using Xunit;

namespace MeatMoreCase.Components.Tests
{
    public class NotFoundTest : TestContext
    {
        [Fact]
        public void NotFoundWithTextShowsWithText()
        {
            var cut = RenderComponent<NotFound>(("Message", "No visitors found"));
            cut.MarkupMatches("<h5 class=\"text-center\">No visitors found</h5>");
        }
    }
}
