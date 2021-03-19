using AccountBalanceDDD.Application.Commands;
using AccountBalanceDDD.Domain;
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
        public static Guid id = new Guid("41b8a258-afc3-46c1-ae68-1ba16228e6dc");
        public static Dictionary<Guid, List<Event>> data = new Dictionary<Guid, List<Event>>
        {
            {
                id, new List<Event>{ new AccountOpened(Guid.NewGuid(),"fatma"),
                    new CashDeposited(Guid.NewGuid(),300)
            } 
            } 
        };
        private static readonly IEventsRepository<Account> repository = new Repository<Account>(data);
        private CommandHandler commandHandler = new CommandHandler(repository);

        [Theory]
        [InlineData("fatma")]
        [InlineData("Rihab")]
        public void ShouldCreateEvent(string name)
         {
            var cmd = new CreateAccount(Guid.NewGuid(),name);
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
            Assert.Equal(500, account.Balance);
        }    
        
        [Theory]
        [InlineData(100)]
        [InlineData(400)]
        public void ShouldWithDrownCash(decimal ammount)
        {
            var cmd = new WithDrown(id, ammount);
            commandHandler.Handle(cmd);
            var account = repository.Find(id);
            Assert.Equal(200, account.Balance);
        }
        [Theory]
        [InlineData(500)]
        public void ShouldBlockAccount(decimal amount)
        {
            var cmd = new WithDrown(id, amount);
            commandHandler.Handle(cmd);
            var account = repository.Find(id);
            Assert.False(account.AccountStatus);
               
        }

        [Theory]
        [InlineData(400)]
        public void ShouldUnblock(decimal amount)
        {
            // when balance <0 , and we handle a deposit event should unblock
            var cmd = new DepositCash(id, amount);
            commandHandler.Handle(cmd);
            var account = repository.Find(id);
            Assert.True(account.AccountStatus);
        }
      
        [Theory]
        [InlineData(100)]
        public void ShoudTransfert(decimal amount)
        {
            var cmd = new Transfert(id, amount);
            commandHandler.Handle(cmd);
            var account = repository.Find(id);
            Assert.Equal(200, account.Balance);
            Assert.Equal(0, account.Daily_wire_tranfert_limit);
        }

    }
}
