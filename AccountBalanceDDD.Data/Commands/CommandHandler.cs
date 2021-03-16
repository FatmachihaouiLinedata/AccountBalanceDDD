using AccountBalanceDDD.Domain;
using AccountBalanceDDD.Domain.Aggregate;
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

            Account account = new Account(command.Id, command.Name_holder, command.OverDraftLimit, command.OverDraftLimit);
            _eventsRepository.Save(account.Id, new AccountOpenedEvent(account));
        }      
        public void Handle(DepositCash command)
        {
            Event account = _eventsRepository.Find(command.AccountId);
            if (account == null)
                throw new ArgumentOutOfRangeException(nameof(command.AccountId), "invalid account id");


            else
            {
              //  account.DepositCash(command.Ammount);
              //  _eventsRepository.Save(account);
            }

        }

       public void Handle(DepositCheque command)
       {
            var account = _eventsRepository.Find(command.AccountId);
            if(account== null)
                throw new ArgumentOutOfRangeException(nameof(command.AccountId), "invalid account id");
            else
            {
              //  account.DepositCheque(command.Ammount);
                //_eventsRepository.Save(account);
            }

        }
    }
}
