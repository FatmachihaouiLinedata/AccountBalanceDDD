using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Domain.Events
{
    public class ChequeDepositedEvent : Event<Account,Guid>
    {
        public decimal Ammount { get; set; }
        public Guid AccountId { get; set; }
        public ChequeDepositedEvent(Account account, decimal ammount)
        {
            AccountId = account.Id;
            Ammount = ammount;
        }
    }
}
