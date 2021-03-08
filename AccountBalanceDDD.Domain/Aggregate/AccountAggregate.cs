using AccountBalanceDDD.Domain.Events;
using System;

namespace AccountBalanceDDD.Domain.Aggregate
{
    public class AccountAggregate : AggregateRoot
    {
        public override AggregateState CreateState() => new Account();

        public void OpenAccount(Guid id, string name_holder, DateTime openDate)
        {
            var e = new AccountOpenedEvent(id, name_holder, openDate);
            Apply(e);
        }

        public void DepositCash(Guid id, decimal ammount, DateTime depotDate)
        {
            var e = new CashDepositedEvent(id, ammount, depotDate);
            Apply(e);
        }

        public void DepositCheque(Guid id, decimal ammount, DateTime depotDate)
        {
            var e = new ChequeDepositedEvent(id, ammount, depotDate);
            Apply(e);
        }
    }
}
