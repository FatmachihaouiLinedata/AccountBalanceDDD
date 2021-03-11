using AccountBalanceDDD.Domain.Aggregate;
using System;

namespace AccountBalanceDDD.Application.Commands
{
    public interface ICommandHandler<T>
    {
        public void Handle(T command);
    }
}
