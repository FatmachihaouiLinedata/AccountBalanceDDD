using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalanceDDD.Application.Commands
{
    public class CreateAccount 
    {
        public Guid Id { get; private set; }
        public string Name_holder { get; set; }
        public decimal OverDraftLimit { get; set; }
        public decimal Daily_wire_tranfert_limit { get; set; }
        public decimal Balance { get; set; }
        public bool AccountStatus { get; set; }
        public CreateAccount(Guid id, string name_holder, decimal overdraftlimit, decimal dailywiretransfertlimit)
        {

            Id = id;
            Name_holder = name_holder;
            OverDraftLimit = overdraftlimit;
            Daily_wire_tranfert_limit = dailywiretransfertlimit;
            Balance = 0;
            AccountStatus = true;
        }
    }
}
