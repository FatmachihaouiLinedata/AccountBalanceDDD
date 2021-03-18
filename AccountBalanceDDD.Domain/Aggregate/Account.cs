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
            Id = id;
            Name_holder = name_holder;
            Apply(new AccountOpened(id,name_holder));
           
        }
       
        public void DepositCash(decimal ammount)
        {
            if (ammount < 0) throw new ArgumentOutOfRangeException(nameof(ammount), "amount should be >0");
           
            Apply(new CashDeposited(Id,ammount));
        }

        public void DepositCheque(decimal ammount)
        {
            if (CheckDateValid(DateTime.UtcNow) == false) throw new Exception("deposit cheque in progress");
           
            Apply(new ChequeDeposited(Id, ammount));

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
                AccountStatus = false; // blocked event
              

            }
           else Apply(new Withdrown(Id,amount));
        }
        public void Transfert()
        {
            // to do
        }

       

      
      public override void Apply(Event @event)
       {
            switch (@event)
            {
                case AccountOpened e:
                    Id = e.Id;
                    Name_holder = e.Name_holder;
                    OverDraftLimit = 100;
                    Daily_wire_tranfert_limit = 100;
                    AccountStatus = true;
                    Balance = 0;

                    break;
                case CashDeposited c:
                    Balance += c.Ammount;

                    break;
                case Withdrown w:
                    Balance -= w.Ammount;
            
                break;

                
            }
        }
    
    }
}

