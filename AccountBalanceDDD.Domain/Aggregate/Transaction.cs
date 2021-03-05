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
        public TransactionType TransactionType { get; set; }
        public decimal Ammount { get; set; }
        public DateTime DateTransaction { get; set; }
        public bool Status { get; set; }

        public Transaction()
        {

        }
        public Transaction(Guid id, TransactionType transaction_Type, decimal ammount, DateTime dateTransaction, bool status)
        {
            Id = id;
            TransactionType = transaction_Type;
            Ammount = ammount;
            DateTransaction = dateTransaction;
            Status = status;
        }
    }
}
