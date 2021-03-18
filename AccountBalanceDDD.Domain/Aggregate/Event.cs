using System;

namespace AccountBalanceDDD.Domain.Aggregate
{
    public class Event 
    { 
        protected Event()
        {

        }
        public Guid Id { get;  set; }

        public DateTime OperationDate { get; private set; }

        public long Version { get; private set; }

        
    }
}
