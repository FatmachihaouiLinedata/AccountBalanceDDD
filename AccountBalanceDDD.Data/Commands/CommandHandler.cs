using AccountBalanceDDD.Domain;
using AccountBalanceDDD.Domain.Repositories;
using System;

namespace AccountBalanceDDD.Application.Commands
{
    public class CommandHandler 
    {
        private IEventsRepository<Account, Guid> _eventsRepository;
        public CommandHandler(IEventsRepository<Account, Guid> eventsRepository)
        {
            _eventsRepository = eventsRepository;

        }
       
        public void Handle(CreateAccount command)
        {
            var account = _eventsRepository.Find(command.Id);
            if (account != null)
                throw new Exception("account already exist");

            else
            {
                account = new Account(command.Id, command.Name_holder, command.OverDraftLimit, command.Daily_wire_tranfert_limit);
                _eventsRepository.Save(account);
            }
        
        }

       
        public void Handle(DepositCash command)
        {
            var account = _eventsRepository.Find(command.AccountId);
            if (account == null)
                throw new ArgumentOutOfRangeException(nameof(command.AccountId), "invalid account id");


            else
            {
                account.DepositCash(command.Ammount);
                _eventsRepository.Save(account);
            }

        }

       
    }
}
