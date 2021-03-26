using System;

namespace AccountBalanceDDD.Application.Commands
{
    public class DepositCheque 
    {
        public decimal Amount { get; set; }
        public Guid AccountId { get; set; }
        public DepositCheque(Guid accountId, decimal amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
}
