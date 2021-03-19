using AccountBalanceDDD.Domain.Aggregate;
using AccountBalanceDDD.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountBalanceDDD.Domain.Repositories
{
    public class Repository<T> : IEventsRepository<T> where T : AggregateRoot, new()
    {
      public Dictionary<Guid, List<Event>> _data = new Dictionary<Guid, List<Event>>();
        public Repository(Dictionary<Guid, List<Event>> data)
        {
            _data = data;
        }
        public void Save(T aggregateRoot, Event @event)
        {
            if (_data.ContainsKey(aggregateRoot.Id))
            {
                _data[aggregateRoot.Id].Add(@event);
            }
            else
            {
                _data.Add(aggregateRoot.Id, new List<Event>());
            }
            aggregateRoot.Apply(@event);
        }

       

        T IEventsRepository<T>.Find(Guid id)
        {
            T account = new T();

            List<Event> events;

             if (!_data.ContainsKey(id))

                account = null;
            
             else
             if (_data.TryGetValue(id, out events))
             {
               
                foreach (var e in events)
                {
                    account.Apply(e);
                }
              
             }
            return account;

        }
    }
}
