using AccountBalanceDDD.Application.Commands;
using AccountBalanceDDD.Domain;
using AccountBalanceDDD.Domain.Aggregate;
using AccountBalanceDDD.Domain.Events;
using AccountBalanceDDD.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace AccountBalanceDDD.Tests
{// to do
    [ExcludeFromCodeCoverage]
    public class AccountBalanceTest
    {
        public static Dictionary<Guid, List<Event>> data = new Dictionary<Guid, List<Event>>();
        
        private readonly IEventsRepository repository = new Repository(data);


       [Fact]
       public void ShouldCreateEvent()
        {
            Guid id = Guid.NewGuid();

           Account account = new Account(id, "fatma", 100, 100);
            var mockRepo = new Mock<IEventsRepository>();
            mockRepo.Setup(x => x.Save(id,new AccountOpenedEvent(account)));

           Assert.NotNull(repository.Find(id));
           
       }


       
    }
}
