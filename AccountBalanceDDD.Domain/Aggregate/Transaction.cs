using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalanceDDD.Domain
{
    public enum TransactionType
    {
        Widhdrown, Transfert, DepositCheque, DepositCash
    }
    public class Transaction
    {
        public Guid Id { get; set; }
        public TransactionType _transactionType { get; set; }
        public decimal Ammount { get; set; }
        public DateTime DateTransaction { get; set; }

        public Transaction(Guid id, TransactionType transactionType, decimal ammount, DateTime dateTransaction)
        {
            Id = id;
            _transactionType = transactionType;
            Ammount = ammount;
            DateTransaction = dateTransaction;
        }
    }
}
