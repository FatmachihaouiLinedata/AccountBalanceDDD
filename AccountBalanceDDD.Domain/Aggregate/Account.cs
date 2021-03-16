using AccountBalanceDDD.Domain.Aggregate;
using AccountBalanceDDD.Domain.Events;
using System;

namespace AccountBalanceDDD.Domain
{
    public class Account  : AggregateRoot
    {
        public string Name_holder { get; set; }
        public decimal OverDraftLimit { get; set; }
        public decimal Daily_wire_tranfert_limit { get; set; }
        public decimal Balance { get; set; }
        public bool AccountStatus { get; set; }

        public override Guid Id { get; set; }

             
        public Account()
        {

        }
        public Account(Guid id, string name_holder, decimal overdraftlimit, decimal dailywiretransfertlimit)
        {
            Id = id;
            Name_holder = name_holder;
            OverDraftLimit = overdraftlimit;
            Daily_wire_tranfert_limit = dailywiretransfertlimit;
            Balance = 0;
            ApplyChange(new AccountOpenedEvent(this));
        }

        public void DepositCash(decimal ammount)
        {
            if (ammount < 0) throw new ArgumentOutOfRangeException(nameof(ammount), "amount should be >0");
            Balance += ammount; 
            ApplyChange(new CashDepositedEvent(this, ammount));
        }

        public void DepositCheque(decimal ammount)
        {
            if (CheckDateValid(DateTime.UtcNow) == false) throw new Exception("deposit cheque in progress");
            Balance += ammount;
            ApplyChange(new ChequeDepositedEvent(this, ammount));

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

        private bool CheckifCanWithdrow(decimal amount)
        {
            if ((Balance < 0) && (Math.Abs(Balance - amount) > OverDraftLimit)) return false;
            return true;
        }


        public void Withdrow(decimal amount)
        {
            // block account if check is false
            if (CheckifCanWithdrow(amount) == false)
            {
                AccountStatus = false;
                Balance -= amount;

            }
           else ApplyChange(new WithdrownEvent(amount));
        }
        public void Transfert()
        {
        }

        protected override void Apply(Event @event)
        {
            switch (@event)
            {
                case AccountOpenedEvent e:
                    new Account(e.Id, e.Name_holder, OverDraftLimit, Daily_wire_tranfert_limit);

                    break;
                case CashDepositedEvent c:
                    DepositCash(c.Ammount);
                                    
                    break;
                case WithdrownEvent w:
                    Withdrow(w.Ammount);
                    break;

                case TransfertCreatedEvent t:
                    Transfert();
                    break;
            }
        }
    }
}

