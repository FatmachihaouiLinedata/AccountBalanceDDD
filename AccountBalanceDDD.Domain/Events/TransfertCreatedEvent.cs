using AccountBalanceDDD.Domain.Aggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalanceDDD.Domain.Events
{
    public class TransfertCreatedEvent : Event
    {
        public Guid FromAccountId { get; set; }
        public Guid ToAccountId { get; set; }
        public decimal Ammount { get; set; }
        public decimal TotalDailyAmmount { get; set; }

        public TransfertCreatedEvent(Guid id, Guid fromAccountId, Guid toAccountId, decimal ammount, decimal totalDailyAmmount, DateTime transfertDate)
        {
            Id = id;
            FromAccountId = fromAccountId;
            ToAccountId = toAccountId;
            Ammount = ammount;
            TotalDailyAmmount = totalDailyAmmount;
            OperationDate = transfertDate;
        }
    
        
    }

}
