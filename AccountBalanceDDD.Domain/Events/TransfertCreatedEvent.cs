using AccountBalanceDDD.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalanceDDD.Domain.Events
{
    public class TransfertCreatedEvent : Event
    {
        public Guid FromAccountId { get; set; }
        public Guid ToAccountId { get; set; }
        public decimal Ammount { get; set; }

        public TransfertCreatedEvent(Guid fromAccountId, Guid toAccountId, decimal ammount)
        {
            FromAccountId = fromAccountId;
            ToAccountId = toAccountId;
            Ammount = ammount; 
        }
    
    }

}
