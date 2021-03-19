using System;

namespace AccountBalanceDDD.Domain.Aggregate
{
    public class Event 
    { 
        
        public Guid Id { get;  set; }
        public DateTime OperationDate { get; private set; }

        protected Event()
        {
            Id = Guid.NewGuid();
            OperationDate = DateTime.UtcNow;
        }

    }
}
