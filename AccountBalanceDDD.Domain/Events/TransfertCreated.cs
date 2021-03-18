using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Domain.Events
{
    public class TransfertCreated : Event
    {
        public Guid FromAccountId { get; set; }
        public Guid ToAccountId { get; set;}
        public decimal Ammount { get; set;}

        public TransfertCreated(Account fromAccount, Account toAccount, decimal ammount)
        {
            FromAccountId = fromAccount.Id;
            ToAccountId = toAccount.Id;
            Ammount = ammount;
        }
    
        
    }

}
