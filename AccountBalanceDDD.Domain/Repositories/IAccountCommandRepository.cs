using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalanceDDD.Domain.Repositories
{
    public interface IAccountCommandRepository
    {
        public void CreateAccount(Account account);

        public void DepositCash(Account account, Transaction transaction);

        public void DepositCheque(Account account, Transaction transaction);

        



    }
}
