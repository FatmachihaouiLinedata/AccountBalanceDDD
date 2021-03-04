namespace AccountBalanceDDD.Domain.Repositories
{
    public class AccountCommandsRepository //: IAccountCommandRepository
    {
        public void CreateAccount(Account account)
        {
            //Applying AddAccountEventCreated in  EventStore
        }
    }
}
