using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Infrastructure.DataAccess.RepositoryModel;
using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Presentation.Console.AtmModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab5.Lab5.Presentation.Console.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.Lab5.Console.ConsoleCode;

public static class Program
{
    public static void Main()
    {
        const string connection = "User ID=postgres;Password=limosha;Host=localhost;Port=5432;Database=Lab5Database";
        var db = new CrudRepository(connection);
        var atm = new Atm(db);
        const string systemPassword = "admin";
        var console = new AtmConsole(atm, systemPassword, db);
        console.Go();
    }
}