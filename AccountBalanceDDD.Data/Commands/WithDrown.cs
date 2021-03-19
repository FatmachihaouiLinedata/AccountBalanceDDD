using System;

namespace AccountBalanceDDD.Application.Commands
{
    public class WithDrown
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }

        public WithDrown(Guid id, decimal amount)
        {
            AccountId = id;
            Amount = amount;
        }
    }
}
