using Bunit;
using Xunit;

namespace MeatMoreCase.Components.Tests
{
    public class LoadingTest : TestContext
    {
        [Fact]
        public void LoadingWithoutTextShouldntShowText()
        {
            var cut = RenderComponent<Loading>();
            cut.MarkupMatches("<div class=\"text-center\"><button class=\"btn\" disabled><span class=\"spinner-border spinner-border-sm text-danger mr-1\" role=\"status\" aria-hidden=\"true\"></span></button></div>");
        }

        [Fact]
        public void LoadingWithTextShouldShowSpinnerAndText()
        {
            var cut = RenderComponent<Loading>(("Text", "Loading visitors"));
            cut.MarkupMatches("<div class=\"text-center\"><button class=\"btn\" disabled><span class=\"spinner-border spinner-border-sm text-danger mr-1\" role=\"status\" aria-hidden=\"true\"></span><span>Loading visitors</span></button></div>");
        }
    }
}
