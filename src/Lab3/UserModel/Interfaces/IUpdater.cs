using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.ResultModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserModel.Interfaces;

public interface IUpdater
{
    MessageInteractionResult UpdateMessageState(Message message);
}