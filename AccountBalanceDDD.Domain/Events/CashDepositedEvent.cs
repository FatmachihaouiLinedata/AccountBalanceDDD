using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Domain.Events
{
    public class CashDepositedEvent :Event
    {
        public Guid AccountId { get; set; }
        public decimal Ammount { get; set; }
        public CashDepositedEvent(Account account, decimal amount)
        {
            AccountId = account.Id;
            Ammount = amount;
           
        }
        

    }
}
