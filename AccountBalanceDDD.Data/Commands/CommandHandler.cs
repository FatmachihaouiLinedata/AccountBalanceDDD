using AccountBalanceDDD.Domain;
using AccountBalanceDDD.Domain.Events;
using AccountBalanceDDD.Domain.Repositories;
using System;

namespace AccountBalanceDDD.Application.Commands
{
    public class CommandHandler
    {
        public readonly IEventsRepository<Account> _eventsRepository;
        public CommandHandler(IEventsRepository<Account> eventsRepository)
        {
            _eventsRepository = eventsRepository;

        }

        public void Handle(CreateAccount command)
        {
            var account = _eventsRepository.TryFind(command.AccountId);
            if (account != null)
            {
                throw new ArgumentException("account already exist");
            }
            else
            {
                Account accountcreated = new Account(command.AccountId, command.Name_holder);
                _eventsRepository.Save(accountcreated, new AccountOpened(command.AccountId, command.Name_holder));
            }
               
           
        }
        public void Handle(DepositCash command)
        {

            var account = _eventsRepository.TryFind(command.AccountId);
            if (account != null)  
            {
                if(account.CheckifBlocked(command.Amount))
                {
                    _eventsRepository.Save(account, new AccountUnblocked(command.AccountId));

                }

               _eventsRepository.Save(account, new CashDeposited(command.AccountId, command.Amount));
    
            }else
         
              throw new ArgumentOutOfRangeException(nameof(command.AccountId), "invalid account id");
                    
        }

        public void Handle(DepositCheque command)
        {
            var account = _eventsRepository.TryFind(command.AccountId);
            if (account != null)
            {
                _eventsRepository.Save(account, new CashDeposited(command.AccountId, command.Amount));
            }
         
            throw new ArgumentOutOfRangeException(nameof(command.AccountId), "invalid account id");
        }

        public void Handle(WithDrown command)
        {
            var account = _eventsRepository.TryFind(command.AccountId);
            if (account != null)
            {
                if (account.CheckifCanWithdrow(command.Amount))
                {
                    _eventsRepository.Save(account, new AccountBlocked(command.AccountId));
                    return;
                }

                _eventsRepository.Save(account, new Withdrown(command.AccountId, command.Amount));
            }
            
            throw new ArgumentNullException(nameof(command.AccountId), "invalid account id");
        }

        public void Handle(Transfert command)
        {
            var account = _eventsRepository.TryFind(command.AccountId);
            if (account == null)
                throw new ArgumentNullException(nameof(command.AccountId), "invalid account id");
            else
            {
                if(account.CheckIfCanTransfert(command.Amount))
                {
                    _eventsRepository.Save(account, new TransfertCreated(command.AccountId, command.Amount));

                }
                else
                   
                _eventsRepository.Save(account, new AccountBlocked(account.Id));
            }

        }
    }
}