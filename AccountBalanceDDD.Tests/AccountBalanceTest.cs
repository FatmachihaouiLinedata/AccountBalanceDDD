using AccountBalanceDDD.Domain.Aggregate;
using System;
using System.Collections.Generic;
using Xunit;

namespace AccountBalanceDDD.Tests
{// to do
    public class AccountBalanceTest
    {

        [Fact]
        public void ShouldOpenAccount()
        {
            AccountAggregate a = new AccountAggregate();
      //      a.OpenAccount(Guid.NewGuid(), "fatma chihaoui");
            List<Event> liste = a.GetEvents();
            Console.WriteLine(liste);
        }




        [Fact]
        public void DepositCashTest()
        {
            AccountAggregate a = new AccountAggregate();
            Guid id = Guid.NewGuid();
       //     a.OpenAccount(id, "fatma");
            a.DepositCash(id, 105, DateTime.Now);
           

        }
    
        [Fact]
        public void DepositChequeTest()
        {

         
        }
    }
}
