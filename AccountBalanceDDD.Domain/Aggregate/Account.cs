using AccountBalanceDDD.Domain.Aggregate;
using AccountBalanceDDD.Domain.Events;
using System;

namespace AccountBalanceDDD.Domain
{
    public class Account  : AggregateRoot
    {
        
        private string Name_holder;
        private decimal OverDraftLimit;
        private decimal Daily_wire_tranfert_limit;
        private decimal Balance;
        private bool AccountStatus;

        public string name_holder
        {
            get { return Name_holder; }
        }
        
   

        public decimal balance
        {
            get { return Balance; }
        }
        public decimal dailywiretransfertlimit
        {
            get { return Daily_wire_tranfert_limit; }
        }
        public bool accountStatus
        {
            get { return AccountStatus; }
        }


        public override Guid Id { get; set; }

        public Account()
        {

        }
    
        public Account(Guid accountId, string nameHolder)
        {    
            if (accountId == null)
                throw new ArgumentNullException("id should not be null");
            if (string.IsNullOrEmpty(nameHolder))
                throw new ArgumentNullException("please enter valid name");
            else
            {
                Id = accountId;
                Name_holder = nameHolder;
            }
       
        }
        public bool CheckifBlocked(decimal amount)
        {
            return ((AccountStatus == false) && (amount + Balance > 0));

        }

        public bool CheckDateValid(DateTime depositDate)
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

        public bool CheckifCanWithdrow(decimal amount)
        {
            if (AccountStatus == false) throw new Exception("account blocked please deposit money to unblock");
            if (amount <= 0) throw new ArgumentException("amount should be valid");

            if ((Balance + OverDraftLimit) - amount < 0) return false;
            else
                return true;
        }

        public bool CheckIfCanTransfert(decimal amount)
        {
            return ((Balance + OverDraftLimit) - amount > 0 || amount < Daily_wire_tranfert_limit);
        }

       
      public override void Apply(Event @event)
       {
            switch (@event)
            {
                case AccountOpened e:
                    Id = e.AccountId;
                    Name_holder = e.Name_holder;
                    OverDraftLimit = 100;
                    Daily_wire_tranfert_limit = 100;
                    AccountStatus = true;
                    Balance = 0;
                    break;

                case CashDeposited c:
                    Balance += c.Amount;
                    break;

                case Withdrown w:
                    Balance = Balance - w.Amount;
                    break;

                case AccountBlocked b:
                    AccountStatus = false;
                break;
                case AccountUnblocked u:
                    AccountStatus = true;
                break;
                case TransfertCreated t:
                    Daily_wire_tranfert_limit = Daily_wire_tranfert_limit - t.Amount; // setdailytransfert limit
                    Balance -= t.Amount;
                break;
            }
        }
    
    }
}

