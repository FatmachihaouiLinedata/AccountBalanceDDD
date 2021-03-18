using AccountBalanceDDD.Domain.Aggregate;
using AccountBalanceDDD.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountBalanceDDD.Domain.Repositories
{
    public class Repository : IEventsRepository
    {
      public Dictionary<Guid, List<Event>> _data = new Dictionary<Guid, List<Event>>();
        public Repository(Dictionary<Guid, List<Event>> data)
        {
            _data = data;
        }
        public void Save(Guid id, Event @event)
        {
            List<Event> events;
            if (_data.TryGetValue(id, out events))
            {
                events.Add(@event);
                _data[id] = events;
                
            }

            else
            {
                List<Event> myevents = new List<Event>();
                myevents.Add(@event);
                _data.Add(id, myevents);

            }
        }

       
        Account IEventsRepository.Find(Guid id)
         {
            var account = new Account();
            List<Event> events;
            if (_data.TryGetValue(id, out events))
            account.Load(events);
            var lastevt = events[events.Count - 1];

            account.Apply(lastevt);
                

            return account;
         }
     }
}
