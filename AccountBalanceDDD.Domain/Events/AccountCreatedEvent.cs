using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalanceDDD.Domain.Events
{
    public class AccountCreatedEvent
    {
        public Guid Id { get; set; }
        public string Name_holder { get; set; }
        public decimal OverDraftLimit { get; set; }
        public decimal Daily_wire_tranfert_limit { get; set; }
        public decimal Balance { get; set; }

        public AccountCreatedEvent(Guid id, string name_holder, decimal overdraftLimit, decimal dailywireTransfertLimit, decimal balance)
        {
            Id = id;
            Name_holder = name_holder;
            OverDraftLimit = overdraftLimit;
            Daily_wire_tranfert_limit = dailywireTransfertLimit;
            Balance = balance;

        }
    }
}
