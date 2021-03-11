using AccountBalanceDDD.Domain.Aggregate;
using AccountBalanceDDD.Domain.Events;
using System;

namespace AccountBalanceDDD.Domain
{
    public class Account  : AggregateRoot<Account,Guid>
    {
        public Guid Id { get; private set; }
        public string Name_holder { get; set; }
        public decimal OverDraftLimit { get; set; }
        public decimal Daily_wire_tranfert_limit { get; set; }
        public decimal Balance { get; set; }
        public bool AccountStatus { get; set; }

        private Account()
        {

        }
        public Account(Guid id, string name_holder, decimal overdraftlimit, decimal dailywiretransfertlimit)
        {
            Id = id;
            Name_holder = name_holder;
            OverDraftLimit = overdraftlimit;
            Daily_wire_tranfert_limit = dailywiretransfertlimit;
            Balance = 0;
            AddEvent(new AccountOpenedEvent(this));
        }

        public void DepositCash(decimal ammount)
        {
            if (ammount < 0) throw new ArgumentOutOfRangeException(nameof(ammount), "amount should be >0");
            AddEvent(new CashDepositedEvent(this, ammount));
        }

        public void DepositCheque(decimal ammount)
        {
            if (CheckDateValid(DateTime.UtcNow) == false) throw new Exception("deposit cheque in progress");

            AddEvent(new ChequeDepositedEvent(this, ammount));
          
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
            if (CheckifCanWithdrow(amount) == false) AccountStatus = false;
            else AddEvent(new WithdrownEvent(amount));
        }
        public void Transfert()
        {
        }

        protected override void Apply(IEvent<Guid> @event)
        {
            switch (@event)
            {
                case AccountOpenedEvent e:
                    Id = e.Id;
                    Balance = 0;
                    Name_holder = e.Name_holder;
                    
                    break;
                case CashDepositedEvent c:
                    Balance += c.Ammount;
                    break;
                case WithdrownEvent d:
                    Balance -= d.Ammount;
                    break;

                case TransfertCreatedEvent t:
                  
                    break;
            }
        }

        
        public static Account Create(string name_holder, decimal overdraftlimit, decimal dailywiretransfertlimit)
        {
            return new Account(Guid.NewGuid(), name_holder, overdraftlimit, dailywiretransfertlimit);
        }
    }
}

