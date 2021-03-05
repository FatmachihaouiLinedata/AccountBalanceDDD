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
        List<TransfertCreatedEvent> tranferts { get; set; }

        public Account()
        {
        }

        public void DepositCash(CashDepositedEvent @event)
        {//need to check account state
             Balance += @event.Ammount;
           
        }

        public void DepositCheque(ChequeDepositedEvent @event)
        {
            if (CheckDateValid(@event.OperationDate))
            {
                Balance += @event.Ammount;           
            }
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

        public void TransfertFromAccount(TransfertCreatedEvent @event)
        {
            Id = @event.FromAccountId;
            Balance -= @event.Ammount;
        }
       public decimal TotalDailyTransfert(Account account, DateTime date)
        {
            // should i add event to see total ammount of transfert per day 
            return 0;
        }
    }
}

