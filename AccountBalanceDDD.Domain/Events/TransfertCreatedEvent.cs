using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Domain.Events
{
    public class TransfertCreatedEvent : Event<Account, Guid>
    {
        public Guid FromAccountId { get; set; }
        public Guid ToAccountId { get; set;}
        public decimal Ammount { get; set;}

        public TransfertCreatedEvent(Account fromAccount, Account toAccount, decimal ammount)
        {
            FromAccountId = fromAccount.Id;
            ToAccountId = toAccount.Id;
            Ammount = ammount;
        }
    
        
    }

}
