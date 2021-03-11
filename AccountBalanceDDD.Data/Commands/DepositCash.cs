using AccountBalanceDDD.Domain;
using System;

namespace AccountBalanceDDD.Application.Commands
{
    public class DepositCash 
    {
        public Guid AccountId { get; set; }
        public decimal Ammount { get; set; }
        public DepositCash(Account account, decimal amount)
        {
            AccountId = account.Id;
            Ammount = amount;

        }
    }
}
