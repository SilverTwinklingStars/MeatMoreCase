using System;

namespace MeatMoreCase.Core.Models
{
    public class VisitorDay
    {
        private int _visitorId;
        private Visitor _visitor;
        private int _dayId;
        private Day _day;
        private TimeSpan _arrival;
        private TimeSpan? _departure;

        public int VisitorId
        {
            get { return _visitorId; }
            set { _visitorId = value; }
        }

        public Visitor Visitor
        {
            get { return _visitor; }
            set { _visitor = value; }
        }

        public int DayId
        {
            get { return _dayId; }
            set { _dayId = value; }
        }

        public Day Day
        {
            get { return _day; }
            set { _day = value; }
        }

        public TimeSpan Arrival
        {
            get { return _arrival; }
            set { _arrival = value; }
        }

        public TimeSpan? Departure
        {
            get { return _departure; }
            set { _departure = value; }
        }

        public void LeaveBuilding()
        {
            if (!Departure.HasValue)
                Departure = DateTime.Now.TimeOfDay;
        }

        public bool HasVisitorLeft => Departure.HasValue;
        public TimeSpan Duration => HasVisitorLeft ? Departure.Value.Subtract(Arrival) : DateTime.Now.TimeOfDay.Subtract(Arrival);
    }
}
