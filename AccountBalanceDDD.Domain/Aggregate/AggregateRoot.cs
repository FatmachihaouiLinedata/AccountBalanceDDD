using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace AccountBalanceDDD.Domain.Aggregate
{
    public abstract class AggregateRoot<TA, Guid> : BaseEntity<Guid>, IAggregateRoot<Guid> where TA : class, IAggregateRoot<Guid>
    {
        private readonly Queue<IEvent<Guid>> _events = new Queue<IEvent<Guid>>();
        public long Version { get; private set; }
        protected abstract void Apply(IEvent<Guid> @event);
        private static readonly ConstructorInfo CTor;

        public AggregateRoot()
        {

        }
        public AggregateRoot(Guid id) : base(id)
        {

        }
        static AggregateRoot()
        {
            var aggregateType = typeof(TA);
            CTor = aggregateType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public,
                null, new Type[0], new ParameterModifier[0]);
            if (null == CTor)
                throw new InvalidOperationException($"Unable to find required private parameterless constructor for Aggregate of type '{aggregateType.Name}'");
        }
        public IReadOnlyCollection<IEvent<Guid>> Events => _events.ToImmutableArray();

        public void AddEvent(IEvent<Guid> @event)
        {
            _events.Enqueue(@event);
            this.Apply(@event);
            this.Version++;
        }
        public static TA Create(IEnumerable<IEvent<Guid>> events)
        {
            if (null == events || !events.Any())
                throw new ArgumentNullException(nameof(events));
            var result = (TA)CTor.Invoke(new object[0]);

            var aggregate = result as AggregateRoot<TA, Guid>;
            if (aggregate != null)
                foreach (var @event in events)
                    aggregate.AddEvent(@event);
            return result;
        }
    }
}
