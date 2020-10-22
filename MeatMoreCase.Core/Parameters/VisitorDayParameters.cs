using MeatMoreCase.Core.Models;
using System;

namespace MeatMoreCase.Core.Parameters
{
    public class VisitorDayParameters
    {
        public int VisitorId { get; set; }
        public int DayId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? Date { get; set; }
        public VisitorDayState VisitorDayState { get; set; }
        public string[] Includes { get; set; }
    }
}
