using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Domain.Events
{
    public class CashDeposited :Event
    {
        public Guid AccountId { get; set; }
        public decimal Ammount { get; set; }
        public CashDeposited(Guid id, decimal amount)
        {
            AccountId = id;
            Ammount = amount;
           
        }
        

    }
}
