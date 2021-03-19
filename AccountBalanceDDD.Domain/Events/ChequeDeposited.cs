using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Domain.Events
{
    public class ChequeDeposited : Event
    {
        public decimal Amount { get; set; }
        public Guid AccountId { get; set; }
        public ChequeDeposited(Guid id, decimal amount)
        {
            AccountId = id;
            Amount = amount;
        }
       
    }
}
