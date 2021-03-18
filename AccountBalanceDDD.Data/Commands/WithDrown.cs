using System;

namespace AccountBalanceDDD.Application.Commands
{
    public class WithDrown
    {
        public Guid AccountId { get; set; }
        public decimal Ammount { get; set; }

        public WithDrown(Guid id, decimal ammount)
        {
            AccountId = id;
            Ammount = ammount;

        }
    }
}
