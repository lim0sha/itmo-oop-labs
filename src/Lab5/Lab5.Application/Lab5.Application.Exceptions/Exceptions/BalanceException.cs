namespace Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Exceptions.Exceptions;

public class BalanceException : ArgumentException
{
    public BalanceException() { }

    public BalanceException(string context) : base(context) { }

    public BalanceException(string context, Exception baseEx) : base(context, baseEx) { }
}