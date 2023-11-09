using System;


class AccountManager
{
    public void CreateAccount(string accountHolder)
    {
        Console.WriteLine($"Created a new account for {accountHolder}");
    }
}

class TransactionHandler
{
    public void Deposit(int accountNumber, decimal amount)
    {
        Console.WriteLine($"Deposited ${amount} into account #{accountNumber}");
    }

    public void Withdraw(int accountNumber, decimal amount)
    {
        Console.WriteLine($"Withdrawn ${amount} from account #{accountNumber}");
    }
}

class NotificationService
{
    public void SendNotification(string message)
    {
        Console.WriteLine($"Notification: {message}");
    }
}

class BankingFacade
{
    private AccountManager accountManager;
    private TransactionHandler transactionHandler;
    private NotificationService notificationService;

    public BankingFacade()
    {
        accountManager = new AccountManager();
        transactionHandler = new TransactionHandler();
        notificationService = new NotificationService();
    }

    public void CreateAccountAndDeposit(string accountHolder, decimal initialDeposit)
    {
        accountManager.CreateAccount(accountHolder);
        int accountNumber = GenerateAccountNumber(); // Simulated account number generation
        transactionHandler.Deposit(accountNumber, initialDeposit);
        notificationService.SendNotification($"Account created for {accountHolder}, initial deposit: ${initialDeposit}");
    }

    private int GenerateAccountNumber()
    {
        return new Random().Next(1000, 9999);
    }
}
