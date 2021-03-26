using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Domain.Events
{
    public class CashDeposited :Event
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public CashDeposited(Guid accountId, decimal amount)
        {
            AccountId = accountId;
            Amount = amount;
           
        }
        

    }
}
