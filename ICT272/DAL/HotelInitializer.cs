using ICT272.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT272.DAL
{
    public class HotelInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<HotelContext>
    {
       /* public List<Event> events = new List<Event>()
            {
                new Event { EventID = 12, EventTime = DateTime.Parse("2023-01-07"), Description="It is birthday party" , Cost=1000},
                new Event { EventID = 13, EventTime = DateTime.Parse("2023-02-07"), Description="It is reception party" , Cost= 2000},
                new Event { EventID = 14, EventTime = DateTime.Parse("2023-03-07"), Description="It is anniversary party", Cost= 3000 }

            };
        protected override void Seed(HotelContext context)
        {
            var attendees = new List<Attendee>
            {
            new Attendee{Name="Bhupen", AttendeeID=001, EventID=1},
            new Attendee{Name="Shrija", AttendeeID=021, EventID=2},
            new Attendee{Name="Naresh", AttendeeID=001, EventID=2},

            };

            attendees.ForEach(s => context.Attendees.Add(s));
            context.SaveChanges();
            var courses = new List<Event>
            {
                new Event { EventID = 12, EventType = Weeding, EventTime = DateTime.Parse("2023-01-07") },
                new Event { EventID = 13, EventType = , EventTime = DateTime.Parse("2023-02-07") },
                new Event { EventID = 14, EventType = , EventTime = DateTime.Parse("2023-03-07") }

            };
            Event.ForEach(s => context.PartyEvents.Add((Event)s));
            context.SaveChanges();
            var PartyType = new List<EventType>
            {
                new EventType {EventTypeID = 11, Type="Birthday"},
                new EventType {EventTypeID = 12, Type="Weeding"},
                new EventType {EventTypeID = 13, Type="Business Seminar"}
            };
            PartyType.ForEach(s => context.partyTypes.Add(s));
            context.SaveChanges();
        }*/
    }
}