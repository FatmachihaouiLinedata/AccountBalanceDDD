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
            var account = _eventsRepository.Find(command.AccountId);
            if (account == null)
            {
                account = new Account();
                account.Id = command.AccountId;
                _eventsRepository.Save(account, new AccountOpened(command.AccountId, command.Name_holder));

            }
            else
                throw new ArgumentException("account already exist");
        }
        public void Handle(DepositCash command)
        {

            var account = _eventsRepository.Find(command.AccountId);
            if (account == null)
                throw new ArgumentOutOfRangeException(nameof(command.AccountId), "invalid account id");
            else
            {
                account.Id = command.AccountId;
                if ((account.AccountStatus == false) && (command.Amount + account.Balance > 0))
                {
                    account.AccountStatus = true;
                    _eventsRepository.Save(account, new Unblocked(command.AccountId, true));
                }


                _eventsRepository.Save(account, new CashDeposited(command.AccountId, command.Amount));
            }
        }

        public void Handle(DepositCheque command)
        {
            var account = _eventsRepository.Find(command.AccountId);
            if (account == null)
                throw new ArgumentOutOfRangeException(nameof(command.AccountId), "invalid account id");
            else
            {
                if (account.CheckDateValid(DateTime.UtcNow) == false) throw new Exception("deposit cheque in progress");
                else
                    _eventsRepository.Save(account, new CashDeposited(command.AccountId, command.Amount));
            }

        }

        public void Handle(WithDrown command)
        {
            var account = _eventsRepository.Find(command.AccountId);
            if (account == null)
                throw new ArgumentNullException(nameof(command.AccountId), "invalid account id");
            else
            {
                if (account.CheckifCanWithdrow(command.Amount) == false)
                {

                    account.AccountStatus = false;
                    account.Id = command.AccountId;
                    _eventsRepository.Save(account, new Blocked(command.AccountId, account.AccountStatus));
                    return;
                }

                account.Id = command.AccountId;
                _eventsRepository.Save(account, new Withdrown(command.AccountId, command.Amount));
            }
        }

        public void Handle(Transfert command)
        {
            var account = _eventsRepository.Find(command.AccountId);
            if (account == null)
                throw new ArgumentNullException(nameof(command.AccountId), "invalid account id");
            else
            {
                if ((account.Balance + account.OverDraftLimit) - command.Amount < 0 || command.Amount > account.Daily_wire_tranfert_limit)
                {
                    account.Id = command.AccountId;
                    _eventsRepository.Save(account, new Blocked(account.Id, false));
                }
                else
                    account.Id = command.AccountId;
                _eventsRepository.Save(account, new TransfertCreated(command.AccountId, command.Amount));
            }

        }
    }
}