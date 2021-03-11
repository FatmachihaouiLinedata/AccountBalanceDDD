namespace AccountBalanceDDD.Domain.Aggregate
{
    public interface IEntity<out Guid>
    {
         Guid Id { get; }
    }
}