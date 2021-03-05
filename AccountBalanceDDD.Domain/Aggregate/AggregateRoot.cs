using System.Collections.Generic;

namespace AccountBalanceDDD.Domain.Aggregate
{
    public abstract class AggregateRoot
    {
        private readonly List<Event> events = new List<Event>();

    }
}
