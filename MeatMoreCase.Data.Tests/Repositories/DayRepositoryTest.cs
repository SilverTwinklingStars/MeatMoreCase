using MeatMoreCase.Core.Models;
using MeatMoreCase.Core.Repositories;
using MeatMoreCase.Data.Tests.Data;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MeatMoreCase.Data.Tests.Repositories
{
    public class DayRepositoryTest
    {
        private readonly DummyDbContext _dummyDbContext;
        private readonly Mock<IDayRepository> _dayRepositoryMock;
        private readonly IDayRepository _dayRepository;

        public DayRepositoryTest()
        {
            _dummyDbContext = new DummyDbContext();
            _dayRepositoryMock = new Mock<IDayRepository>();
            _dayRepository = _dayRepositoryMock.Object;
        }

        [Fact]
        public async Task GetDayByYesterdaysDate_ReturnsADay()
        {
            _dayRepositoryMock.Setup(dr => dr.GetDayByDate(DateTime.Now.Date)).ReturnsAsync(_dummyDbContext.Yesterday);
            var day = await _dayRepository.GetDayByDate(DateTime.Now.Date);
            Assert.NotNull(day);
            Assert.Equal(DateTime.Now.Date.AddDays(-1), day.Date);
        }

        [Fact]
        public async Task GetDayByTomorrowsDate_ReturnsNoDay()
        {
            _dayRepositoryMock.Setup(dr => dr.GetDayByDate(DateTime.Now.AddDays(1))).ReturnsAsync((Day)null);
            var day = await _dayRepository.GetDayByDate(DateTime.Now.AddDays(1));
            Assert.Null(day);
        }
    }
}
