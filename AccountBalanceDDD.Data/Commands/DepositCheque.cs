﻿using System;

namespace AccountBalanceDDD.Application.Commands
{
    public class DepositCheque 
    {
        public decimal Amount { get; set; }
        public Guid AccountId { get; set; }
        public DepositCheque(Guid id, decimal amount)
        {
            AccountId = id;
            Amount = amount;
        }
    }
}
