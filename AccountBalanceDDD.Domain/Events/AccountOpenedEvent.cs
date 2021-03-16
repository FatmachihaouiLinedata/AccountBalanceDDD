using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Domain.Events
{
    public class AccountOpenedEvent : Event
    { 
      
        public string Name_holder { get; set; }
       
        public AccountOpenedEvent(Account account)
        {
            Id = account.Id;
            Name_holder = account.Name_holder;
        }
     
    }
}
