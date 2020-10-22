using MeatMoreCase.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeatMoreCase.Data
{
    public class MeatMoreDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public MeatMoreDataInitializer(ApplicationDbContext dbContext, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

            _dbContext = dbContext;
        }

        public async Task InitializeDataAsync()
        {
            await _dbContext.Database.EnsureDeletedAsync();
            await _dbContext.Database.EnsureCreatedAsync();

            await _userManager.CreateAsync(new IdentityUser { UserName = "admin", Email = "admin@meatmore.com" }, "admin123");

            #region Visitors
            var visitor1 = new Visitor() { LastName = "Steeman", FirstName = "Lukas", VisitType = VisitType.Applicant };
            var visitor2 = new Visitor() { LastName = "De Boeck", FirstName = "Jan", CompanyName = "Slagerij Rosseels", VisitType = VisitType.Supplier };
            var visitor3 = new Visitor() { LastName = "Van Daele", FirstName = "Koen", LicensePlate = "1-AAA-001", VisitType = VisitType.Visit };
            var visitor4 = new Visitor() { LastName = "Bracke", FirstName = "Bram", VisitType = VisitType.Applicant };
            var visitor5 = new Visitor() { LastName = "De Gucht", FirstName = "Tom", CompanyName = "VTM", LicensePlate = "2-AAA-002", VisitType = VisitType.Supplier };
            var visitor6 = new Visitor() { LastName = "De Schutter", FirstName = "Anke", VisitType = VisitType.Applicant };
            var visitor7 = new Visitor() { LastName = "Schoofs", FirstName = "Julie", VisitType = VisitType.Visit };
            var visitor8 = new Visitor() { LastName = "De Bleecker", FirstName = "Ann", VisitType = VisitType.Supplier };

            var visitors = new List<Visitor> { visitor1, visitor2, visitor3, visitor4, visitor5, visitor6, visitor7, visitor8 };
            _dbContext.Visitors.AddRange(visitors);
            _dbContext.SaveChanges();
            #endregion

            #region Days
            var day1 = new Day { Date = DateTime.Now.Date.AddDays(-2) };
            var day2 = new Day { Date = DateTime.Now.Date.AddDays(-1) };

            var days = new List<Day> { day1, day2 };
            _dbContext.Days.AddRange(days);
            _dbContext.SaveChanges();
            #endregion

            #region VisitorDays
            var visitorDay1 = new VisitorDay { Visitor = visitor1, Day = day1, Arrival = new TimeSpan(12, 00, 00), Departure = new TimeSpan(17, 00, 00) };
            var visitorDay2 = new VisitorDay { Visitor = visitor2, Day = day2, Arrival = new TimeSpan(08, 00, 00), Departure = new TimeSpan(08, 30, 00) };
            var visitorDay3 = new VisitorDay { Visitor = visitor3, Day = day2, Arrival = new TimeSpan(10, 00, 00), Departure = new TimeSpan(11, 00, 00) };
            var visitorDay4 = new VisitorDay { Visitor = visitor4, Day = day2, Arrival = new TimeSpan(16, 00, 00), Departure = new TimeSpan(18, 00, 00) };
            var visitorDay5 = new VisitorDay { Visitor = visitor5, Day = day2, Arrival = new TimeSpan(14, 15, 00), Departure = new TimeSpan(17,15,00) };
            var visitorDay6 = new VisitorDay { Visitor = visitor6, Day = day2, Arrival = new TimeSpan(09, 00, 00), Departure = new TimeSpan(09, 45, 00) };
            var visitorDay7 = new VisitorDay { Visitor = visitor7, Day = day2, Arrival = new TimeSpan(09, 05, 00), Departure = new TimeSpan(10, 45, 00) };
            var visitorDay8 = new VisitorDay { Visitor = visitor8, Day = day2, Arrival = new TimeSpan(09, 10, 00), Departure = new TimeSpan(09, 55, 00) };

            var visitorDays = new List<VisitorDay> { visitorDay1, visitorDay2, visitorDay3, visitorDay4, visitorDay5, visitorDay6, visitorDay7, visitorDay8 };
            _dbContext.VisitorDays.AddRange(visitorDays);
            _dbContext.SaveChanges();
            #endregion
        }
    }
}
