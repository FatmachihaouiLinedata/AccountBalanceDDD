using AccountBalanceDDD.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalanceDDD.Domain.Events
{
    public class AccountBlocked : Event
    {
        public Guid AccountId { get; set; }
        // true = active / false = blocked
       

        public AccountBlocked(Guid accountId)
        {
            AccountId = accountId;
         
        }
    
    }
}
