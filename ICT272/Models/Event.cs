using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ICT272.Models
{
    public class Event
    {
        public int EventId { get; set; }
        [Required]
        public string EventName { get; set; }
        public int EventTypeId { get; set; }
        public DateTime EventTime { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        internal static void ForEach(Func<object, Event> p)
        {
            throw new NotImplementedException();
        }
    }
}