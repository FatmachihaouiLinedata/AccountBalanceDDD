using AccountBalanceDDD.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace AccountBalanceDDD.Tests
{
    public class AccountBalanceTest
    {
        [Fact]
        public void DepositCashTest()
        {
            Account a = new Account()
            {
                Id = Guid.NewGuid(),
                AccountStatus = true,
               Balance = 200,
               Daily_wire_tranfert_limit = 300,
                Name_holder = "fatma",
                OverDraftLimit = 150
            };
            a.DepositCash(100, DateTime.Today);

          
             Assert.Equal(300, a.Balance);

      
        }
    
        [Fact]
        public void DepositChequeTest()
        {
            Account a = new Account()
            {
                Id = Guid.NewGuid(),
                AccountStatus = true,
                Balance = 200,
                Daily_wire_tranfert_limit = 300,
                Name_holder ="fatma",
                OverDraftLimit = 150
            };
            Transaction t=  a.DepositCheque(200, DateTime.Today);
            Assert.False(t.Status);

         
        }
    }
}
