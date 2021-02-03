using System;

public class BankAccount
{
    private enum BankAccountState { Open, Closed }

    private static readonly object ConcurrencyLock = new object();

    private BankAccountState _state = BankAccountState.Closed;
    private decimal _balance;

    public decimal Balance
    {
        get
        {
            lock (ConcurrencyLock)
            {
                ValidateAccountIsOpen();
                return _balance;
            }
        }
    }

    public void Open()
    {
        lock (ConcurrencyLock)
        {
            _state = BankAccountState.Open;
        }
    }

    public void Close()
    {
        lock (ConcurrencyLock)
        {
            _state = BankAccountState.Closed;
        }
    }

    public void UpdateBalance(decimal change)
    {
        ValidateAccountIsOpen();
        lock (ConcurrencyLock)
        {
            _balance += change;
        }
    }

    private void ValidateAccountIsOpen()
    {
        if (_state != BankAccountState.Open)
        {
            throw new InvalidOperationException("Account is not open");
        }
    }
}