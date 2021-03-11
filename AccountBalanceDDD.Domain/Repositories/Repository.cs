using AccountBalanceDDD.Domain.Aggregate;
using System.Collections.Generic;

namespace AccountBalanceDDD.Domain.Repositories
{
    public class Repository<Account, Guid> : IEventsRepository<Account,Guid> where Account : class,IAggregateRoot<Guid>
    {
        public Dictionary<Account, List<Event<Account, Guid>>> _streamevents = new Dictionary<Account, List<Event<Account, Guid>>>();

        public Account Find(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Account aggregateRoot)
        {
            throw new System.NotImplementedException();
        }
    }
}
