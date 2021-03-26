using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Domain.Repositories
{
    public interface IEventsRepository<T> where T : AggregateRoot, new()
    {
         T TryFind(Guid id);
         void Save(T aggregateRoot, Event @event);

    }
}
