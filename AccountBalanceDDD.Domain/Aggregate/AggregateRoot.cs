using System;
using System.Collections.Generic;
namespace AccountBalanceDDD.Domain.Aggregate
{
    public abstract class AggregateRoot 
    {
        private readonly List<Event> _events = new List<Event>();
        public Guid Id { get; protected set; }
        public int Version { get; protected set; }
        public AggregateState State { get; set; }

        public abstract AggregateState CreateState();
        public List<Event> GetEvents()
        {
            return _events;
        }
        protected void Apply(Event @event)
        {
           ApplyEvent(@event);
           _events.Add(@event);
        }

        protected virtual void ApplyEvent(Event @event)
        {
           if (State == null)
              State = CreateState();

           State.Apply(@event);
        }

    }
}
