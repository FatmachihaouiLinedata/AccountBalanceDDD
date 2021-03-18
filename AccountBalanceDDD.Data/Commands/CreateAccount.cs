using System;

namespace AccountBalanceDDD.Application.Commands
{
    public class CreateAccount 
    {
        public Guid AccountId { get; private set; }
        public string Name_holder { get; set; }
        
        public CreateAccount(Guid id, string name_holder)
        {

            AccountId = id;
            Name_holder = name_holder;
           
        }
    }
}
