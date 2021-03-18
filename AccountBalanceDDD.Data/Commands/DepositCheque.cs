using AccountBalanceDDD.Domain;
using System;

namespace AccountBalanceDDD.Application.Commands
{
    public class DepositCheque 
    {
        public decimal Ammount { get; set; }
        public Guid AccountId { get; set; }
        public DepositCheque(Account account, decimal ammount)
        {
            AccountId = account.Id;
            Ammount = ammount;
        }
    }
}
