using System;
using System.Collections.Generic;

namespace AccountBalanceDDD.Domain.Aggregate
{
    public abstract class AggregateRoot
    {
       
        public abstract Guid Id { get; set; }
        public int Version { get;  set; }

        public abstract void Apply(Event @event);
   
    }
}
