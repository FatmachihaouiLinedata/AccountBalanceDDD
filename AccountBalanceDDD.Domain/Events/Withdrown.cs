using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Domain.Events
{
    public class Withdrown : Event
    {
        public Guid AccountId { get; set; }
        public decimal Ammount { get; set; }
        public Withdrown(Guid id, decimal ammount)
        {
           AccountId = id;
           Ammount = ammount;
        }
       

    }
}
