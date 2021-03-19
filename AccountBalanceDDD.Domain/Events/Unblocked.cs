using AccountBalanceDDD.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalanceDDD.Domain.Events
{
    public class Unblocked : Event
    {
        public Guid AccountId { get; set; }
        // true = active / false = blocked
        public bool AccountStatus { get; set; }

        public Unblocked(Guid id, bool accountStatus)
        {
            AccountId = id;
            AccountStatus = accountStatus;

        }
    }
}
