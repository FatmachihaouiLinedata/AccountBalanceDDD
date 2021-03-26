using AccountBalanceDDD.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalanceDDD.Domain.Events
{
    public class AccountUnblocked : Event
    {
        public Guid AccountId { get; set; }

        public AccountUnblocked(Guid accountId)
        {
            AccountId = accountId;

        }
    }
}
