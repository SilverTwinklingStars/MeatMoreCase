using MeatMoreCase.Core.Parameters;
using MeatMoreCase.Core.Repositories;
using MeatMoreCase.Data.Tests.Data;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace MeatMoreCase.Data.Tests.Repositories
{
    public class VisitorDayRepositoryTest
    {
        private readonly DummyDbContext _dummyDbContext;
        private readonly Mock<IVisitorDayRepository> _visitorDayRepositoryMock;
        private readonly IVisitorDayRepository _visitorDayRepository;

        public VisitorDayRepositoryTest()
        {
            _dummyDbContext = new DummyDbContext();
            _visitorDayRepositoryMock = new Mock<IVisitorDayRepository>();
            _visitorDayRepository = _visitorDayRepositoryMock.Object;
        }

        [Fact]
        public async Task GetVisitorDays_WithLastAndFirstName_HasResults()
        {
            var parameters = new VisitorDayParameters
            {
                LastName = "Steeman",
                FirstName = "Lukas"
            };
            _visitorDayRepositoryMock.Setup(vdr => vdr.GetVisitorDay(parameters)).ReturnsAsync(_dummyDbContext.LukasToday);
            var visitorDay = await _visitorDayRepository.GetVisitorDay(parameters);
            Assert.NotNull(visitorDay);
            Assert.Equal("Lukas", visitorDay.Visitor.FirstName);
            Assert.Equal("Steeman", visitorDay.Visitor.LastName);
        }
    }
}
