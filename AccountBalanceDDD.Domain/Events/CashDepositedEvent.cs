using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalanceDDD.Domain.Events
{
    public class CashDepositedEvent
    {
        public Guid Id { get; set; }
        public decimal Ammount { get; set; }

        public CashDepositedEvent(Guid id, decimal ammount)
        {
            Id = id;
            Ammount = ammount;
        }
    }
}
