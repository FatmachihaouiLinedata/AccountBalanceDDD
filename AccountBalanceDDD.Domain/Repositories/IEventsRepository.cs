using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Domain.Repositories
{
    public interface IEventsRepository
    {
         Account Find(Guid id);
         void Save(Guid id, Event @event);

    }
}
