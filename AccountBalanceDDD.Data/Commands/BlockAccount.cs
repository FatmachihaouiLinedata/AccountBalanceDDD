using System;

namespace AccountBalanceDDD.Application.Commands
{
    public class BlockAccount
    {
        public Guid AccountId { get; set; }

        public BlockAccount(Guid id)
        {
            AccountId = id;

        }
    }
}
