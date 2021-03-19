using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Domain.Events
{
    public class TransfertCreated : Event
    {
        public Guid AccountId { get; set; }
      
        public decimal Amount { get; set;}

        public TransfertCreated(Guid id, decimal amount)
        {
            AccountId = id;
            Amount = amount;
        }
    
        
    }

}
