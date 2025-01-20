namespace Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Models.Entities;

public class User
{
    public int Id { get; private set; }

    public double? Balance { get; private set; }

    public int Pin { get; private set; }

    public User(int id, int pin, double? balance)
    {
        if (id <= 0)
            throw new ArgumentException("Account number must be greater than 0", nameof(id));

        if (pin <= 0)
            throw new ArgumentException("PIN must be greater than 0", nameof(pin));

        // if (balance < 0)
        //    throw new ArgumentException("Balance cannot be negative", nameof(balance));
        Id = id;
        Balance = balance;
        Pin = pin;
    }
}