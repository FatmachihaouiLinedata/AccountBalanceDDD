using AccountBalanceDDD.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalanceDDD.Domain.Events
{
    public class ChequeDepositedEvent : Event
    {
        public decimal Ammount { get; set; }
        
        public ChequeDepositedEvent(Guid id, decimal ammount, DateTime depoDate)
        {
            Id = id;
            Ammount = ammount;
            OperationDate = depoDate;
        }
    }
}
