using MeatMoreCase.Core.Models;
using System;
using Xunit;

namespace MeatMoreCase.Core.Tests
{
    public class VisitorDayTest
    {
        [Fact]
        public void Arrival10AMDeparture12PMHasDuration2Hours()
        {
            Visitor visitor = new Visitor() { LastName = "Steeman", FirstName = "Lukas", CompanyName = "Company A", LicensePlate = "1-AAA-001", VisitType = VisitType.Applicant };
            Day today = new Day();
            VisitorDay visitorDay = new VisitorDay()
            {
                Visitor = visitor,
                Day = today,
                Arrival = new TimeSpan(08, 00, 00),
                Departure = new TimeSpan(10, 00, 00)
            };

            Assert.Equal(new TimeSpan(02, 00, 00), visitorDay.Duration);
        }

        [Fact]
        public void VisitorHasntLeftBuildingYet()
        {
            Visitor visitor = new Visitor() { LastName = "Steeman", FirstName = "Lukas", CompanyName = "Company A", LicensePlate = "1-AAA-001", VisitType = VisitType.Applicant };
            Day today = new Day();
            VisitorDay visitorDay = new VisitorDay()
            {
                Visitor = visitor,
                Day = today,
                Arrival = new TimeSpan(08, 00, 00)
            };

            Assert.False(visitorDay.HasVisitorLeft);
            Assert.Null(visitorDay.Departure);
        }

        [Fact]
        public void VisitorLeavesBuildingSuccesfully()
        {
            Visitor visitor = new Visitor() { LastName = "Steeman", FirstName = "Lukas", CompanyName = "Company A", LicensePlate = "1-AAA-001", VisitType = VisitType.Applicant };
            Day today = new Day();
            VisitorDay visitorDay = new VisitorDay()
            {
                Visitor = visitor,
                Day = today,
                Arrival = new TimeSpan(08, 00, 00),
                Departure = new TimeSpan(10, 00, 00)
            };

            visitorDay.LeaveBuilding();
            Assert.True(visitorDay.HasVisitorLeft);
            Assert.NotNull(visitorDay.Departure);
        }
    }
}
