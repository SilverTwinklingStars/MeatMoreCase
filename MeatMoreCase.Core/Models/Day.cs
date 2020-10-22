using System;
using System.Collections.Generic;

namespace MeatMoreCase.Core.Models
{
    public class Day
    {
        private int _dayId;
        private DateTime _date;
        private ICollection<VisitorDay> _visitorDays;

        public ICollection<VisitorDay> VisitorDays
        {
            get { return _visitorDays; }
            set { _visitorDays = value; }
        }

        public int DayId
        {
            get { return _dayId; }
            set { _dayId = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public Day()
        {
            Date = DateTime.Now.Date;
            VisitorDays = new List<VisitorDay>();
        }
    }
}
