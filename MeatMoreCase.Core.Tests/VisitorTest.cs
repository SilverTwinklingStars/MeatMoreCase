using MeatMoreCase.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MeatMoreCase.Core.Tests
{
    public class VisitorTest
    {
        [Fact]
        public void VisitorHasCompany()
        {
            Visitor visitor = new Visitor() { LastName = "Steeman", FirstName = "Lukas", CompanyName = "Company A", LicensePlate = "1-AAA-001", VisitType = VisitType.Applicant };
            Assert.True(visitor.HasCompany);
        }

        [Fact]
        public void VisitorHasNoCompany()
        {
            Visitor visitor = new Visitor() { LastName = "Steeman", FirstName = "Lukas", LicensePlate = "1-AAA-001", VisitType = VisitType.Applicant };
            Assert.False(visitor.HasCompany);
        }
    }
}
