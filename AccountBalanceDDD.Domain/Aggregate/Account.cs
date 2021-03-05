using AccountBalanceDDD.Domain.Events;
using System;
using System.Collections.Generic;

namespace AccountBalanceDDD.Domain
{
    public class Account 
    {
        public Guid Id { get; set; }
        public string Name_holder { get; set; }
        public decimal OverDraftLimit { get; set; }
        public decimal Daily_wire_tranfert_limit { get; set; }
        public decimal Balance { get; set; }
        // blocked / unblocked
        public bool AccountStatus { get; set; }
        public List<Transaction> transactions = new List<Transaction>();

        public Account()
        {
        }

        public void DepositCash(decimal ammount, DateTime depotDate)
        {
            Balance += ammount;
            transactions.Add(new Transaction(Guid.NewGuid(), TransactionType.DepositCash, ammount, depotDate, true));
           
        }

        public Transaction DepositCheque(decimal ammount, DateTime depotDate)
        {
            Transaction transaction = new Transaction(Guid.NewGuid(), TransactionType.DepositCheque, ammount, depotDate, false);
            if (CheckDateValid(depotDate))
            {
                Balance += ammount;
                
                transaction.Status = true;
            }
            transactions.Add(transaction);
            return transaction;
        }

        private  bool CheckDateValid(DateTime depositDate)
        {
            string todaysDate, nextDay;
            todaysDate = DateTime.Now.ToString();

            if (depositDate.Day.Equals(5))
            {
                nextDay = Convert.ToString(depositDate.AddDays(2));
            }
            else
                nextDay = Convert.ToString(depositDate.AddDays(1));

            if (todaysDate.Equals(nextDay))
            {
                return true;
            }
            return false;
        }


        public void TransfertFromAccount(Account fromAccount, Account toAccount, decimal Ammount, DateTime transfertDate)
        {
           
            // check dailywiretransfert (fromAccount)
            if (Decimal.Compare(TotalDailyTransfert(fromAccount, transfertDate), fromAccount.Daily_wire_tranfert_limit) == -1)
                fromAccount.AccountStatus = false;
            else
            {
                fromAccount.transactions.Add(new Transaction(Guid.NewGuid(), TransactionType.Transfert, Ammount, transfertDate, true));
                fromAccount.Balance -= Ammount;

                toAccount.Balance += Ammount;
                toAccount.transactions.Add(new Transaction(Guid.NewGuid(), TransactionType.DepositCash, Ammount, transfertDate, true));
            }

        }
       public decimal TotalDailyTransfert(Account account, DateTime date)
        {
           
            decimal cumulTransfertAmmount = 0;
            foreach(var transaction in account.transactions)
            {
                if(transaction.DateTransaction.Equals(date) && transaction.TransactionType.Equals(TransactionType.Transfert)) 
                {
                    cumulTransfertAmmount += transaction.Ammount;
                }
            }

            return cumulTransfertAmmount;
        }
    }
}

