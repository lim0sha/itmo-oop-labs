using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Abstractions.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Models.Entities;
using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Presentation.Console.AtmModel.Entities;
using System.Globalization;
using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab5.Lab5.Presentation.Console.Console;

public class AtmConsole : IAtmConsole
{
    private readonly Atm _atm;
    private readonly ICrudRepository _iCrudRepository;
    private readonly string _password;

    public AtmConsole(Atm atm, string password, ICrudRepository repository)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Password can not be null", nameof(password));
        }

        _atm = atm ?? throw new ArgumentNullException(nameof(atm), "Atm can not be null");
        _password = password;
        _iCrudRepository = repository ?? throw new ArgumentNullException(nameof(repository), "Repository can not be null");
    }

    public void Go()
    {
        while (true)
        {
            System.Console.WriteLine("Choose ATM option:");
            System.Console.WriteLine("1. User");
            System.Console.WriteLine("2. Admin");
            System.Console.WriteLine("3. Exit menu");

            string? request = System.Console.ReadLine();

            switch (request)
            {
                case "1":
                    UserConsole();
                    break;
                case "2":
                    AdminConsole();
                    break;
                case "3":
                    return;
                default:
                    System.Console.WriteLine("No option provided. Choose 1/2/3.");
                    break;
            }
        }
    }

    private int GenerateUserId()
    {
        using var generator = RandomNumberGenerator.Create();
        byte[] bytes = new byte[16];
        generator.GetBytes(bytes);
        using var sha256 = SHA256.Create();
        byte[] hash = sha256.ComputeHash(bytes);
        int number = BitConverter.ToInt32(hash, 0) & int.MaxValue;
        return (number % 9000) + 1000;
    }

    private void UserConsole()
    {
        System.Console.WriteLine("Enter account id:");
        int userId = int.Parse(System.Console.ReadLine() ?? throw new Exception(), CultureInfo.InvariantCulture);
        System.Console.WriteLine("Enter PIN:");
        int pin = int.Parse(System.Console.ReadLine() ?? throw new Exception(), CultureInfo.InvariantCulture);

        while (true)
        {
            System.Console.WriteLine("Choose ATM option:");
            System.Console.WriteLine("1. Show balance");
            System.Console.WriteLine("2. Deduce money");
            System.Console.WriteLine("3. Contribute money");
            System.Console.WriteLine("4. Show payment list");
            System.Console.WriteLine("5. Change account pin-code");
            System.Console.WriteLine("6. Go menu-back");

            string? request = System.Console.ReadLine();

            switch (request)
            {
                case "1":
                    ShowBalance(userId, pin);
                    break;
                case "2":
                    Deduce(userId, pin);
                    break;
                case "3":
                    Contribute(userId, pin);
                    break;
                case "4":
                    ShowPaymentList(userId, pin);
                    break;
                case "5":
                    UpdatePin(userId);
                    break;
                case "6":
                    return;
                default:
                    System.Console.WriteLine("No option provided. Choose 1/2/3/4/5/6.");
                    break;
            }
        }
    }

    private void ShowBalance(int userId, int pin)
    {
        var query = new AtmQuery
        {
            UserId = userId,
            Pin = pin,
            Command = "ShowBalance",
        };

        _atm.ProcessRequest(query);
    }

    private void Deduce(int userId, int pin)
    {
        System.Console.WriteLine("Enter amount to deduce:");
        double amount = double.Parse(System.Console.ReadLine() ?? throw new Exception(), CultureInfo.InvariantCulture);

        var query = new AtmQuery
        {
            UserId = userId,
            Pin = pin,
            Command = "Deduce",
            PaymentAmount = amount,
        };

        _atm.ProcessRequest(query);
    }

    private void Contribute(int userId, int pin)
    {
        System.Console.WriteLine("Enter amount to contribute:");
        double amount = double.Parse(System.Console.ReadLine() ?? throw new Exception(), CultureInfo.InvariantCulture);

        var query = new AtmQuery
        {
            UserId = userId,
            Pin = pin,
            Command = "Contribute",
            PaymentAmount = amount,
        };

        _atm.ProcessRequest(query);
    }

    private void ShowPaymentList(int userId, int pin)
    {
        var query = new AtmQuery
        {
            UserId = userId,
            Pin = pin,
            Command = "ShowPaymentList",
        };

        _atm.ProcessRequest(query);
    }

    private void UpdatePin(int userId)
    {
        System.Console.WriteLine("Enter new PIN:");
        int pin = int.Parse(System.Console.ReadLine() ?? throw new Exception(), CultureInfo.InvariantCulture);
        var query = new AtmQuery { UserId = userId, UpdatedPin = pin, Command = "UpdatePIN" };

        _atm.ProcessRequest(query);
    }

    private void AdminConsole()
    {
        System.Console.WriteLine("Enter password:");
        string? password = System.Console.ReadLine();

        if (password != _password)
        {
            System.Console.WriteLine("Wrong password, bro");
            return;
        }

        while (true)
        {
            System.Console.WriteLine("Choose option:");
            System.Console.WriteLine("1. Create account");
            System.Console.WriteLine("2. Go back to menu");

            string? request = System.Console.ReadLine();

            switch (request)
            {
                case "1":
                    CreateAccount();
                    break;
                case "2":
                    return;
                default:
                    System.Console.WriteLine("No option provided");
                    break;
            }
        }
    }

    private void CreateAccount()
    {
        System.Console.WriteLine("Enter PIN:");
        int pin = int.Parse(System.Console.ReadLine() ?? throw new Exception(), CultureInfo.InvariantCulture);
        int userId;
        do
        {
            userId = GenerateUserId();
        }
        while (_iCrudRepository.HasAccount(userId));

        System.Console.WriteLine("Your account id is: " + userId);

        var query = new AtmQuery
        {
            UserId = userId,
            Pin = pin,
            Command = "CreateAccount",
        };

        _atm.ProcessRequest(query);
    }
}
