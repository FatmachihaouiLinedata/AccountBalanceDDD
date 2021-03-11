using System;

namespace AccountBalanceDDD.Domain.Aggregate
{
    public abstract class Event<TA, Guid> : IEvent<Guid> where TA : IAggregateRoot<Guid>
    {
        protected Event()
        {

        }
        public Guid Id { get; private set; }

        public DateTime OperationDate { get; private set; }

        public long Version { get; private set; }

        protected Event(TA aggregateRoot)
        {
            Version = aggregateRoot.Version;
            Id = aggregateRoot.Id;
            OperationDate = DateTime.UtcNow;
        }
    }
}
