using System;
using System.Collections.Generic;

namespace AccountBalanceDDD.Domain.Aggregate
{
    public abstract class AggregateRoot
    {
        private readonly List<Event> _events = new List<Event>();
        public abstract Guid Id { get; set; }
        public int Version { get;  set; }
      
        protected abstract void Apply(Event @event);

        public IEnumerable<Event> GetEvents(Guid id)
        {
           return _events;
        }
        protected void ApplyChange(Event @event)
        {
            Apply(@event);
            _events.Add(@event);

        }
       
        
    }
}
