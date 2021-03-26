using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Domain.Events
{
    public class TransfertCreated : Event
    {
        public Guid AccountId { get; set; }
      
        public decimal Amount { get; set;}

        public TransfertCreated(Guid accountId, decimal amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    
        
    }

}
