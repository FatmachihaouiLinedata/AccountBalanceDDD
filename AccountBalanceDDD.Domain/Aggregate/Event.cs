using System;

namespace AccountBalanceDDD.Domain.Aggregate
{
    public abstract class Event
    {
        public Guid Id { get; set; }
        public DateTime OperationDate { get; set; }
        public int Version { get; set; }
    }

}
