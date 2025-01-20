using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserModel.Interfaces;

public interface ISender
{
    void Send(IRecipient recipient, Message message);
}