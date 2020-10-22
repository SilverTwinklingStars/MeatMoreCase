using MeatMoreCase.Core.Models;
using System;
using System.Collections.Generic;

namespace MeatMoreCase.Data.Tests.Data
{
    public class DummyDbContext
    {
        public Visitor Lukas { get; set; }
        public Visitor Jan { get; set; }
        public Visitor An { get; set; }
        public IEnumerable<Visitor> Visitors { get; set; }
        public Day DayBeforeYesterday { get; set; }
        public Day Yesterday { get; set; }
        public IEnumerable<Day> Days { get; set; }
        public VisitorDay LukasToday { get; set; }
        /// <summary>
        /// Jan visits today, still in the building.
        /// </summary>
        public VisitorDay JanToday { get; set; }
        public VisitorDay AnDayBeforeYesterday { get; set; }
        public IEnumerable<VisitorDay> VisitorDays { get; set; }

        public DummyDbContext()
        {
            #region Visitors
            Lukas = new Visitor()
            {
                VisitorId = 1,
                LastName = "Steeman",
                FirstName = "Lukas",
                VisitType = VisitType.Applicant
            };

            Jan = new Visitor()
            {
                VisitorId = 2,
                LastName = "De Beule",
                FirstName = "Jan",
                CompanyName = "VTM",
                LicensePlate = "1-AAA-001",
                VisitType = VisitType.Supplier
            };

            An = new Visitor()
            {
                VisitorId = 3,
                LastName = "De Cock",
                FirstName = "An",
                LicensePlate = "1-AAA-002",
                VisitType = VisitType.Visit
            };

            Visitors = new List<Visitor> { Lukas, Jan, An };
            #endregion

            #region Days
            DayBeforeYesterday = new Day() { DayId = 1, Date = DateTime.Now.Date.AddDays(-2) };
            Yesterday = new Day() { DayId = 2, Date = DateTime.Now.Date.AddDays(-1) };

            Days = new List<Day> { DayBeforeYesterday, Yesterday };
            #endregion

            #region VisitorDays
            LukasToday = new VisitorDay()
            {
                VisitorId = Lukas.VisitorId,
                Visitor = Lukas,
                DayId = DayBeforeYesterday.DayId,
                Day = DayBeforeYesterday,
                Arrival = new TimeSpan(10, 00, 00),
                Departure = new TimeSpan(11, 30, 00)
            };

            JanToday = new VisitorDay()
            {
                VisitorId = Jan.VisitorId,
                Visitor = Jan,
                DayId = DayBeforeYesterday.DayId,
                Day = DayBeforeYesterday,
                Arrival = new TimeSpan(15, 00, 00),
                Departure = new TimeSpan(15, 20, 00)
            };

            AnDayBeforeYesterday = new VisitorDay()
            {
                VisitorId = An.VisitorId,
                Visitor = An,
                DayId = Yesterday.DayId,
                Day = Yesterday,
                Arrival = new TimeSpan(09, 00, 00),
                Departure = new TimeSpan(12, 05, 00)
            };

            VisitorDays = new List<VisitorDay> { LukasToday, JanToday, AnDayBeforeYesterday };
            #endregion
        }
    }
}
