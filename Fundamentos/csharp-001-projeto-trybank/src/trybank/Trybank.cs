namespace Trybank.Lib;

public class TrybankLib
{
    public bool Logged;
    public int loggedUser;

    //0 -> Número da conta
    //1 -> Agência
    //2 -> Senha
    //3 -> Saldo
    public int[,] Bank;
    public int registeredAccounts;
    private int maxAccounts = 50;

    public TrybankLib()
    {
        loggedUser = -99;
        registeredAccounts = 0;
        Logged = false;
        Bank = new int[maxAccounts, 4];
    }

    // 1. Construa a funcionalidade de cadastrar novas contas
    public void RegisterAccount(int number, int agency, int pass)
    {
        for (int i = 0; i < Bank.GetLength(0); i++)
        {
            if (Bank[i, 0] == number && Bank[i, 1] == agency)
            {
                throw new ArgumentException("A conta já está sendo usada!");
            }
        }

        int[] newAccount = { number, agency, pass, 0 };

        for (int j = 0; j < newAccount.Length; j++)
        {
            Bank[registeredAccounts, j] = newAccount[j];
        }

        registeredAccounts++;
    }

    // 2. Construa a funcionalidade de fazer Login
    public void Login(int number, int agency, int pass)
    {
        if (Logged)
            throw new AccessViolationException("Usuário já está logado");

        int userIndex = FindUser(number, agency);
        ValidatePassword(userIndex, pass);

        Logged = true;
        loggedUser = userIndex;
    }

    // 3. Construa a funcionalidade de fazer Logout
    public void Logout()
    {
        IsLoggedUser();
        Logged = false;
        loggedUser = -99;
    }

    // 4. Construa a funcionalidade de checar o saldo
    public int CheckBalance()
    {
        IsLoggedUser();
        return Bank[loggedUser, 3];
    }

    // 5. Construa a funcionalidade de depositar dinheiro
    public void Deposit(int value)
    {
        IsLoggedUser();
        Bank[loggedUser, 3] = value;
    }

    // 6. Construa a funcionalidade de sacar dinheiro
    public void Withdraw(int value)
    {
        IsLoggedUser();
        int balance = Bank[loggedUser, 3];
        InsufficientFunds(value);

        Bank[loggedUser, 3] = balance - value;
    }

    // 7. Construa a funcionalidade de transferir dinheiro entre contas
    public void Transfer(int destinationNumber, int destinationAgency, int value)
    {
        IsLoggedUser();

        InsufficientFunds(value);

        for (int i = 0; i < Bank.GetLength(0); i++)
        {
            if (Bank[i, 0] == destinationNumber && Bank[i, 1] == destinationAgency)
            {
                Bank[loggedUser, 3] -= value;
                Bank[i, 3] += value;

                break;
            }
        }
    }


    private void IsLoggedUser()
    {
        if (!Logged)
            throw new AccessViolationException("Usuário não está logado");
    }
    private int FindUser(int accountNumber, int accountAgency)
    {
        for (int i = 0; i < Bank.GetLength(0); i++)
        {
            if (Bank[i, 0] == accountNumber && Bank[i, 1] == accountAgency)
            {
                return i;
            }
        }

        throw new ArgumentException("Agência + Conta não encontrada");
    }

    private void ValidatePassword(int userIndex, int password)
    {
        if (Bank[userIndex, 2] != password)
            throw new ArgumentException("Senha incorreta");
    }

    private void InsufficientFunds(int value)
    {
        if (Bank[loggedUser, 3] < value)
        {
            throw new InvalidOperationException("Saldo insuficiente");
        }

    }
}
