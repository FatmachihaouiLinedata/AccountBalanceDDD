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
        public Account(Guid id, string name_holder)
        {    
            if (id == null)
                throw new ArgumentNullException("id should not be null");
            if (string.IsNullOrEmpty(name_holder))
                throw new ArgumentNullException("please enter valid name");
            Id = id;
            Name_holder = name_holder;
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

                case Blocked b:
                    AccountStatus = false;
                break;
                case Unblocked u:
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

