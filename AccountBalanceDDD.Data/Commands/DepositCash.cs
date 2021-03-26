using System;

namespace AccountBalanceDDD.Application.Commands
{
    public class DepositCash 
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public DepositCash(Guid accountId, decimal amount)
        {
            AccountId = accountId;
            Amount = amount;

        }
    }
}
