using System;
using System.Collections.Generic;

namespace AccountBalanceDDD.Domain
{
    //aggregate root
    public class Account 
    {
        public int Id { get; set; }
        public string Name_holder { get; set; }
        public double OverDraftLimit { get; set; }
        public double Daily_wire_tranfert_limit { get; set; }
        public double Balance { get; set; }
        public List<Transaction> _transactions { get; set; }

        public Account()
        {

        }
        public void AddTransaction(Guid id, TransactionType transactionType, decimal ammount, DateTime dateTransaction)
        {
           _transactions.Add(new Transaction(id, transactionType, ammount, dateTransaction));
        }


    }
}

