using Bunit;
using Xunit;

namespace MeatMoreCase.Components.Tests
{
    public class CardTest : TestContext
    {
        [Fact]
        public void CardWithoutParametersRendersEmptyCard()
        {
            var cut = RenderComponent<Card>();
            cut.MarkupMatches("<div class=\"card \"><div class=\"card-body\"></div></div>");
        }

        [Fact]
        public void CardWithAdditionalStylingRendersStyledCard()
        {
            var cut = RenderComponent<Card>(("Styling", "mb-3"));
            cut.MarkupMatches("<div class=\"card mb-3\"><div class=\"card-body\"></div></div>");
        }

        [Fact]
        public void CardWithHeaderRendersCardWithAHeader()
        {
            var cut = RenderComponent<Card>(("Header", "Visitors"));
            cut.MarkupMatches("<div class=\"card \"><h5 class=\"card-header\">Visitors</h5><div class=\"card-body\"></div></div>");
        }

        [Fact]
        public void CardWithChildContentRendersCardWithBody()
        {
            var childContent = "<div class=\"text-center\"><p>Test body</p></div>";
            var cut = RenderComponent<Card>(parameters => parameters.AddChildContent(childContent));
            cut.MarkupMatches($"<div class=\"card \"><div class=\"card-body\">{childContent}</div></div>");
        }

        [Fact]
        public void CardWithAllParametersFilledInRendersFullCard()
        {
            var childContent = "<div class=\"text-center\"><p>Test body</p></div>";
            var cut = RenderComponent<Card>(parameters => parameters
            .Add(p => p.Styling, "mb-3")
            .Add(p => p.Header, "Visitors")
            .AddChildContent(childContent)
            );

            cut.MarkupMatches($"<div class=\"card mb-3\"><h5 class=\"card-header\">Visitors</h5><div class=\"card-body\">{childContent}</div></div>");
        }
    }
}
