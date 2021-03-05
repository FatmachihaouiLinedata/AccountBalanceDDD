using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalanceDDD.Domain.Aggregate
{
    public abstract class Event
    {
        public Guid AggregateId { get; set; }
        public int Version { get; set; }
        public DateTime OperationDate { get; set; }
    }

}
