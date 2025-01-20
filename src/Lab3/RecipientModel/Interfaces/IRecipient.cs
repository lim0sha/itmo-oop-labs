using Itmo.ObjectOrientedProgramming.Lab3.UserModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Interfaces;

public interface IRecipient : IGetter
{
    string RecipientName { get; init; }
}