using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Domain.Events
{
    public class ChequeDeposited : Event
    {
        public decimal Ammount { get; set; }
        public Guid AccountId { get; set; }
        public ChequeDeposited(Guid id, decimal ammount)
        {
            AccountId = id;
            Ammount = ammount;
        }
       
    }
}
