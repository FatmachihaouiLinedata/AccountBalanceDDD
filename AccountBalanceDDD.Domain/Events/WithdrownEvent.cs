using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Domain.Events
{
    public class WithdrownEvent : Event<Account, Guid>
    {
        public decimal Ammount { get; set; }
        public WithdrownEvent(decimal ammount)
        {
           Ammount = ammount;
        }   
    }
}
