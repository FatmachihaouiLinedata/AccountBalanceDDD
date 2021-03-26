using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Domain.Events
{
    public class Withdrown : Event
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public Withdrown(Guid accountId, decimal amount)
        {
           AccountId = accountId;
           Amount = amount;
        }
       

    }
}
