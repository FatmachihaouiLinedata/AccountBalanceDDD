using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Domain.Events
{
    public class AccountOpenedEvent : Event
    { 
        public string Name_holder { get; set; }
       
        public AccountOpenedEvent(Guid id, string name_holder, DateTime openDate)
        {
            Id = id;
            Name_holder = name_holder;
            OperationDate = openDate;
        }
    }
}
