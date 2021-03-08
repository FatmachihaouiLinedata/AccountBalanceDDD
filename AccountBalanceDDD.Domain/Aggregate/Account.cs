using AccountBalanceDDD.Domain.Aggregate;
using AccountBalanceDDD.Domain.Events;
using System;

namespace AccountBalanceDDD.Domain
{
    public class Account  : AggregateState
    {
        public Guid Id { get; set; }
        public string Name_holder { get; set; }
        public decimal OverDraftLimit { get; set; }
        public decimal Daily_wire_tranfert_limit { get; set; }
        public decimal Balance { get; set; }
        public bool AccountStatus { get; set; }
        
       

        public void Apply(AccountOpenedEvent @event)
        {
            Id = @event.Id;
            Name_holder = @event.Name_holder;
            OverDraftLimit = 100;
            Daily_wire_tranfert_limit = 200;
            Balance = 100;
            AccountStatus = true;
        }

        public void Apply(CashDepositedEvent @event)
        {
             Id = @event.Id;
             Balance += @event.Ammount;
        }

        public void Apply(ChequeDepositedEvent @event)
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

        public void Apply(TransfertCreatedEvent @event)
        {
            if (Daily_wire_tranfert_limit >= @event.TotalDailyAmmount)
            {
                AccountStatus = false;
            }
            else
                Apply(new CashDepositedEvent(@event.Id, @event.Ammount, @event.OperationDate));
        }

       
      
    }
}

