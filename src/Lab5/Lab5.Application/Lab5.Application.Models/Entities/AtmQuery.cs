namespace Itmo.ObjectOrientedProgramming.Lab5.Lab5.Application.Lab5.Application.Models.Entities;

public class AtmQuery
{
    public int UserId { get; init; }

    public int Pin { get; init; }

    public int? UpdatedPin { get; init; }

    public string Command { get; init; } = string.Empty;

    public double? PaymentAmount { get; init; }
}