using AccountBalanceDDD.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalanceDDD.Domain.Events
{
    public class ChequeDepositedEvent : Event
    {
        public Guid Id { get; set; }
        public decimal Ammount { get; set; }
        public ChequeDepositedEvent(Guid id, decimal ammount)
        {
            Id = id;
            Ammount = ammount;
            
        }
    }
}
