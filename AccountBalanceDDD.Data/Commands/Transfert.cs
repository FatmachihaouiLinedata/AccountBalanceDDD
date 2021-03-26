using System;

namespace AccountBalanceDDD.Application.Commands
{
    public class Transfert
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public Transfert(Guid accountId, decimal amount)
        {
            AccountId = accountId;
            Amount = amount;

        }
        
        
    }
}
