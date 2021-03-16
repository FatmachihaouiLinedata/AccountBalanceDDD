using AccountBalanceDDD.Domain.Aggregate;
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
        
        public Event Find(Guid id)
        {
             _data.TryGetValue(id, out List<Event> list);
            if (list != null)
                return list.ElementAt(list.Count-1);
            else
                return null;
        }

        public void Save(Guid id, Event @event)
        {
            List<Event> events = new List<Event>();
            events.Add(@event);
            _data.Add(id, events);
        }
    }
}
