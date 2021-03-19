using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Domain.Events
{
    public class Withdrown : Event
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public Withdrown(Guid id, decimal amount)
        {
           AccountId = id;
           Amount = amount;
        }
       

    }
}
