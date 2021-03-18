using AccountBalanceDDD.Application.Commands;
using AccountBalanceDDD.Domain.Aggregate;
using AccountBalanceDDD.Domain.Events;
using AccountBalanceDDD.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace AccountBalanceDDD.Tests
{// to do
    [ExcludeFromCodeCoverage]
    public class AccountBalanceTest
    {
        public static Guid id = Guid.NewGuid();
        public static Dictionary<Guid, List<Event>> data = new Dictionary<Guid, List<Event>>
        {
            {
                id, new List<Event>{ new AccountOpened(Guid.NewGuid(),"fatma"), 
                    new CashDeposited(Guid.NewGuid(),300)

            } 
            } 
        };
        private static readonly IEventsRepository repository = new Repository(data);
        private CommandHandler commandHandler = new CommandHandler(repository);

       
        [Theory]
        [InlineData("fatma")]
        [InlineData("Rihab")]
        public void ShouldCreateEvent(string name)
         {
            Guid id = Guid.NewGuid();
            var cmd = new CreateAccount(id,name);
            commandHandler.Handle(cmd);
            var account = repository.Find(id);
            Assert.Equal(0, account.Balance);
        }
            
        [Theory]
        [InlineData(200)]
        public void SouldDepositCash(decimal ammount)
        {          
            var cmd = new DepositCash(id, ammount);
            commandHandler.Handle(cmd);
            var account = repository.Find(id);

            account.Load(data[id]);
            Assert.Equal(200, account.Balance);
        }
        [Theory]
        [InlineData(100)]
        public void ShoudDepositCheque(decimal ammount)
        {
            // to do
        }
        [Theory]
        [InlineData(100)]
        public void ShouldWithDrownCash(decimal ammount)
        {
            var cmd = new WithDrown(id, ammount);
            commandHandler.Handle(cmd);
            var account = repository.Find(id);

            account.Load(data[id]);
            Assert.Equal(200, account.Balance);
        }
            
      

    }
}
