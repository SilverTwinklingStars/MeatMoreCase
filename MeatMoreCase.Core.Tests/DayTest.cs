using MeatMoreCase.Core.Models;
using System;
using Xunit;

namespace MeatMoreCase.Core.Tests
{
    public class DayTest
    {
        [Fact]
        public void NewDayHasDateTodayAndEmptyListVisitorDays()
        {
            var day = new Day();
            Assert.Equal(day.Date, DateTime.Now.Date);
            Assert.Empty(day.VisitorDays);
        }
    }
}
