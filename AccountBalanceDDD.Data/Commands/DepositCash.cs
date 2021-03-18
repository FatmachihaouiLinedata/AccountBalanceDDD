using System;

namespace AccountBalanceDDD.Application.Commands
{
    public class DepositCash 
    {
        public Guid AccountId { get; set; }
        public decimal Ammount { get; set; }
        public DepositCash(Guid accountId, decimal amount)
        {
            AccountId = accountId;
            Ammount = amount;

        }
    }
}
