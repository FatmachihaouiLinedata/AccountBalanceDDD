using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Domain.Events
{
    public class WithdrownEvent : Event
    {
        public decimal Ammount { get; set; }
        public Guid Account { get; set; }
        public WithdrownEvent(Guid id, decimal ammount)
        {
            Account = id;
            Ammount = ammount;

        }   
    }
}
