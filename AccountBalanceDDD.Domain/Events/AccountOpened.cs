using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Domain.Events
{
    public class AccountOpened : Event
    {

        public Guid AccountId { get; set; }
        public string Name_holder { get; set; }
       


        public AccountOpened(Guid id, string name_holder)
        {
            AccountId = id;
            Name_holder = name_holder;
          
        }
     
    }
}
