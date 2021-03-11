using System;

namespace AccountBalanceDDD.Domain.Aggregate
{
    public interface IEvent<out Guid>
    {
         Guid Id { get; }
         DateTime OperationDate { get; }
         long Version { get; }
    }

}
