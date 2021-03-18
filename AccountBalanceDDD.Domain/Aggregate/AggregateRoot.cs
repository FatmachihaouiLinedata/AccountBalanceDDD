using System;
using System.Collections.Generic;

namespace AccountBalanceDDD.Domain.Aggregate
{
    public abstract class AggregateRoot
    {
        private readonly List<Event> _events = new List<Event>();
        public abstract Guid Id { get; set; }
        public int Version { get;  set; }

        public abstract void Apply(Event @event);
       
        public void Load(List<Event> events)
        {
            foreach (var e in events)
            _events.Add(e);
        }
        
        
       
        
    }
}
