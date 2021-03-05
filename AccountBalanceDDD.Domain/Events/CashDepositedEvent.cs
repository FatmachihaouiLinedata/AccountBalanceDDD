using AccountBalanceDDD.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalanceDDD.Domain.Events
{
    public class CashDepositedEvent :Event
    {
        public decimal Ammount { get; set; }
        public Guid Account { get; set; }
        public CashDepositedEvent(Guid id, decimal ammount)
        {
            Account = id;
            Ammount = ammount;
        }
    }
}
