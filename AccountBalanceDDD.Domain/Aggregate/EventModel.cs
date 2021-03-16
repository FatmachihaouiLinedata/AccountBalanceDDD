using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalanceDDD.Domain.Aggregate
{
    public class EventModel
    {
        public Event EventData { get; set; }
        public Guid AggregateId { get; set; }


        public EventModel(Guid id, Event @event)
        {
            AggregateId = id;
            EventData = @event;

        }
    }
}
