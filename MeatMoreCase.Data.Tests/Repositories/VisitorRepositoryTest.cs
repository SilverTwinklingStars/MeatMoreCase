using MeatMoreCase.Core.Models;
using MeatMoreCase.Core.Repositories;
using MeatMoreCase.Data.Tests.Data;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace MeatMoreCase.Data.Tests.Repositories
{
    public class VisitorRepositoryTest
    {
        private readonly DummyDbContext _dummyDbContext;
        private readonly Mock<IVisitorRepository> _visitorRepositoryMock;
        private readonly IVisitorRepository _visitorRepository;

        public VisitorRepositoryTest()
        {
            _dummyDbContext = new DummyDbContext();
            _visitorRepositoryMock = new Mock<IVisitorRepository>();
            _visitorRepository = _visitorRepositoryMock.Object;
        }

        [Fact]
        public async Task GetById_Exists_ReturnsAVisitor()
        {
            _visitorRepositoryMock.Setup(vr => vr.GetById(1)).ReturnsAsync(_dummyDbContext.Lukas);
            var visitor = await _visitorRepository.GetById(1);
            Assert.Equal(1, visitor.VisitorId);
        }

        [Fact]
        public async Task GetById_DoesNotExists_ReturnsNull()
        {
            _visitorRepositoryMock.Setup(vr => vr.GetById(10)).ReturnsAsync((Visitor)null);
            var visitor = await _visitorRepository.GetById(10);
            Assert.Null(visitor);
        }
    }
}
