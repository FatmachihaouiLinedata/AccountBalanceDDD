namespace AccountBalanceDDD.Domain.Aggregate
{
    public interface IAggregateRoot<out TKey> : IEntity<TKey>
    {
        long Version { get; }

    }
}
