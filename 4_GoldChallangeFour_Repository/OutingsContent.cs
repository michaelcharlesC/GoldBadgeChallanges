using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_GoldChallangeFour_Repository
{
    public enum EventType
    {
        Golf,
        Bowling,
        AmusementPark,
        Concert,


    }
    public class OutingsContent
    {
        public EventType EventType { get; set; }
        public int Attendees { get; set; }
        public DateTime EventDate { get; set; }
        public double TotalCostPerson { get; set; }
        public double TotalCostEvent { get; set; }
       


        public OutingsContent() { }
        public OutingsContent(EventType eventType,int attendees, DateTime eventDate, double totalCostPerson, double totalCostEvent)
        {
            EventType = eventType;
            Attendees = attendees;
            EventDate = eventDate;
            TotalCostPerson = totalCostPerson;
            TotalCostEvent = totalCostEvent;
        }
    }
}
