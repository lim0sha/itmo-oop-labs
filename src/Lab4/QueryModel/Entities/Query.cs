using Itmo.ObjectOrientedProgramming.Lab4.QueryModel.Interfaces;
using System.Diagnostics.Contracts;

namespace Itmo.ObjectOrientedProgramming.Lab4.QueryModel.Entities;

public class Query : IQuery
{
    private readonly IList<string> _query = [];

    public Query(string commandLineQuery)
    {
        if (string.IsNullOrEmpty(commandLineQuery))
        {
            throw new ArgumentNullException(nameof(commandLineQuery), "Command can not be empty");
        }

        _query = commandLineQuery.Split(' ');
    }

    [Pure]
    public string GetFlag(int index)
    {
        return index < 0
            ? throw new ArgumentOutOfRangeException(nameof(index), "Command flag index must be positive")
            : _query[index];
    }
}