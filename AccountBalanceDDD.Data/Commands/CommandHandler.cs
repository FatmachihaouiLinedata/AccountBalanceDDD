using AccountBalanceDDD.Domain.Events;
using AccountBalanceDDD.Domain.Repositories;
using System;

namespace AccountBalanceDDD.Application.Commands
{
    public class CommandHandler  
    {
        public readonly IEventsRepository _eventsRepository;
        public CommandHandler(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;

        }
       
        public void Handle(CreateAccount command)
        {

            _eventsRepository.Save(command.AccountId, new AccountOpened(command.AccountId, command.Name_holder));
        }      
        public void Handle(DepositCash command)
        {  
                _eventsRepository.Save(command.AccountId, new CashDeposited(command.AccountId,command.Ammount));
        }

       
       public void Handle(DepositCheque command)
       {
            var account = _eventsRepository.Find(command.AccountId);
            if(account== null)
                throw new ArgumentOutOfRangeException(nameof(command.AccountId), "invalid account id");
            else
            {
                account.DepositCheque(command.Ammount);
                _eventsRepository.Save(account.Id, new CashDeposited(command.AccountId,command.Ammount));
            }

        }

        public void Handle(WithDrown command)
        {
            var account = _eventsRepository.Find(command.AccountId);
            if (account == null)
                throw new ArgumentOutOfRangeException(nameof(command.AccountId), "invalid account id");
            else
            {
                account.Withdrow(command.Ammount);
                _eventsRepository.Save(account.Id, new Withdrown(command.AccountId, command.Ammount));
            }
        }
    }
}
