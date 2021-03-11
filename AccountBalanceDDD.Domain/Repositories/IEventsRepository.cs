using AccountBalanceDDD.Domain.Aggregate;

namespace AccountBalanceDDD.Domain.Repositories
{
    public interface IEventsRepository<TA, Guid> where TA : class, IAggregateRoot<Guid>
    {
        public TA Find(Guid id);
        public void Save(TA aggregateRoot);
    }
}
