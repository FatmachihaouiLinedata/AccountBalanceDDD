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
    public class AccountBalanceTest
    {
        public static Guid id = new Guid("41b8a258-afc3-46c1-ae68-1ba16228e6dc");
        public static Dictionary<Guid, List<Event>> data = new Dictionary<Guid, List<Event>>
        {
            {
                id, new List<Event>{ new AccountOpened(id,"fatma"),
                    new CashDeposited(id,300)} 
            } 
        };
        private static readonly IEventsRepository<Account> repository = new Repository<Account>(data);
        private CommandHandler commandHandler = new CommandHandler(repository);

        [Theory]
        [InlineData("fatma")]
        [InlineData("Rihab")]
        public void ShouldCreateEvent(string name)
         {
            Guid newId = Guid.NewGuid();
            var cmd = new CreateAccount(newId, name);
            
            commandHandler.Handle(cmd);
            var account = repository.TryFind(newId);
            Assert.Equal(0, account.balance);
        }
            
        [Theory]
        [InlineData(200)]
        public void SouldDepositCash(decimal ammount)
        {          
            var cmd = new DepositCash(id, ammount);
            commandHandler.Handle(cmd);
            var account = repository.TryFind(id);
            Assert.Equal(500, account.balance);
        }    
        
        [Theory]
        [InlineData(100)]
        [InlineData(400)]
        public void ShouldWithDrownCash(decimal ammount)
        {
            var cmd = new WithDrown(id, ammount);
            commandHandler.Handle(cmd);
            var account = repository.TryFind(id);
            Assert.Equal(200, account.balance);
        }
        [Theory]
        [InlineData(500)]
        public void ShouldBlockAccount(decimal amount)
        {
            var cmd = new WithDrown(id, amount);
            commandHandler.Handle(cmd);
            var account = repository.TryFind(id);
            Assert.False(account.accountStatus);
               
        }

        [Theory]
        [InlineData(400)]
        public void ShouldUnblock(decimal amount)
        {
            // when balance <0 , and we handle a deposit event should unblock
            var cmd = new DepositCash(id, amount);
            commandHandler.Handle(cmd);
            var account = repository.TryFind(id);
            Assert.True(account.accountStatus);
        }
      
        [Theory]
        [InlineData(100)]
        public void ShoudTransfert(decimal amount)
        {
            var cmd = new Transfert(id, amount);
            commandHandler.Handle(cmd);
            var account = repository.TryFind(id);
            Assert.Equal(200, account.balance);
            Assert.Equal(0, account.dailywiretransfertlimit);
        }

    }
}
