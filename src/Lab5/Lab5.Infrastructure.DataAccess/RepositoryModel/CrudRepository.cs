using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Abstractions.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Models.Entities;
using Npgsql;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Itmo.ObjectOrientedProgramming.Lab5.Lab5.Infrastructure.DataAccess.RepositoryModel;

public class CrudRepository : ICrudRepository
{
    private readonly string _connectionString;

    public CrudRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void CreateAccount(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "Account cannot be null");
        }

        ExecuteNonQuery(cmd =>
        {
            cmd.CommandText =
                "INSERT INTO accounts (account_number, pin, balance) VALUES (@account_number, @pin, @balance)";
            cmd.Parameters.AddWithValue("account_number", user.Id);
            cmd.Parameters.AddWithValue("pin", user.Pin);
            cmd.Parameters.AddWithValue("balance", user.Balance ?? (object)DBNull.Value);
        });
    }

    public User GetAccount(int id)
    {
        List<User> accounts = ExecuteReader(
            cmd =>
            {
                cmd.CommandText = "SELECT * FROM accounts WHERE account_number = @account_number";
                cmd.Parameters.AddWithValue("account_number", id);
            },
            reader => new User(
                reader.GetInt32(reader.GetOrdinal("account_number")),
                reader.GetInt32(reader.GetOrdinal("pin")),
                reader.GetDouble(reader.GetOrdinal("balance"))));
        return accounts.FirstOrDefault() ?? throw new InvalidOperationException("Account not found.");
    }

    public void SavePayment(int id, string command, double? amount)
    {
        int operationId = command switch
        {
            "ShowBalance" => (int)OperationType.ShowBalance,
            "Deduce" => (int)OperationType.Deduce,
            "Contribute" => (int)OperationType.Contribute,
            "ShowPaymentList" => (int)OperationType.ShowPaymentList,
            _ => throw new ArgumentException($"Invalid command: {command}"),
        };

        ExecuteNonQuery(cmd =>
        {
            cmd.CommandText =
                "INSERT INTO transactions (account_number, operation, amount) VALUES (@account_number, @operation, @amount)";
            cmd.Parameters.AddWithValue("account_number", id);
            cmd.Parameters.AddWithValue("operation", operationId);
            cmd.Parameters.AddWithValue("amount", amount ?? (object)DBNull.Value);
        });
    }

    public ReadOnlyCollection<string> GetPaymentList(int id)
    {
        List<string> history = ExecuteReader(
            cmd =>
            {
                cmd.CommandText = "SELECT * FROM transactions WHERE account_number = @account_number";
                cmd.Parameters.AddWithValue("account_number", id);
            },
            reader =>
            {
                int operationId = reader.GetInt32(reader.GetOrdinal("operation"));
                string operation = ((OperationType)operationId).ToString();
                decimal amount = reader.GetDecimal(reader.GetOrdinal("amount"));
                return $"{operation}: {amount}";
            });

        return history.AsReadOnly();
    }

    public void UpdatePin(int id, int newPin)
    {
        ExecuteNonQuery(cmd =>
        {
            cmd.CommandText = "UPDATE accounts SET pin = @newPin WHERE account_number = @account_number";
            cmd.Parameters.AddWithValue("newPin", newPin);
            cmd.Parameters.AddWithValue("account_number", id);
        });
    }

    public void UpdateAccount(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "Account cannot be null");
        }

        ExecuteNonQuery(cmd =>
        {
            cmd.CommandText = "UPDATE accounts SET pin = @pin WHERE account_number = @account_number";
            cmd.Parameters.AddWithValue("pin", user.Pin);
            cmd.Parameters.AddWithValue("account_number", user.Id);
        });

        UpdateBalance(user.Id, user.Balance);
    }

    public void UpdatePin(int id, int? newPin)
    {
        if (newPin == null)
        {
            throw new ArgumentNullException(nameof(newPin), "New PIN cannot be null");
        }

        ExecuteNonQuery(cmd =>
        {
            cmd.CommandText = "UPDATE accounts SET pin = @newPin WHERE account_number = @account_number";
            cmd.Parameters.AddWithValue("newPin", newPin);
            cmd.Parameters.AddWithValue("account_number", id);
        });
    }

    public bool HasAccount(int id)
    {
        return ExecuteScalar(
            cmd =>
            {
                cmd.CommandText = "SELECT EXISTS (SELECT 1 FROM accounts WHERE account_number = @account_number)";
                cmd.Parameters.AddWithValue("account_number", id);
            },
            result => Convert.ToBoolean(result, CultureInfo.InvariantCulture));
    }

    private void UpdateBalance(int id, double? balance)
    {
        ExecuteNonQuery(cmd =>
        {
            cmd.CommandText = "UPDATE accounts SET balance = @balance WHERE account_number = @account_number";
            cmd.Parameters.AddWithValue("balance", balance ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("account_number", id);
        });
    }

    private void ExecuteNonQuery(Action<NpgsqlCommand> configureCommand)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using NpgsqlCommand command = connection.CreateCommand();
        configureCommand(command);
        command.ExecuteNonQuery();
    }

    private T? ExecuteScalar<T>(Action<NpgsqlCommand> configureCommand, Func<object, T> convert)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using NpgsqlCommand command = connection.CreateCommand();
        configureCommand(command);

        object result = command.ExecuteScalar() ?? throw new InvalidOperationException();
        return result != DBNull.Value ? convert(result) : default;
    }

    private List<T> ExecuteReader<T>(Action<NpgsqlCommand> configureCommand, Func<NpgsqlDataReader, T> mapReader)
    {
        var results = new List<T>();
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using NpgsqlCommand command = connection.CreateCommand();
        configureCommand(command);
        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            results.Add(mapReader(reader));
        }

        return results;
    }
}