using AccountBalanceDDD.Domain.Aggregate;
using System;
using System.Collections.Generic;

namespace AccountBalanceDDD.Domain.Repositories
{
    public interface IEventsRepository
    {
        public Event Find(Guid id);
        public void Save(Guid id, Event @event);

    }
}
