using System;

namespace AccountBalanceDDD.Application.Commands
{
    public class CreateAccount 
    {
        public Guid AccountId { get; private set; }
        public string Name_holder { get; set; }
        
        public CreateAccount(Guid accountId, string name_holder)
        {

            AccountId = accountId;
            Name_holder = name_holder;
           
        }
    }
}
