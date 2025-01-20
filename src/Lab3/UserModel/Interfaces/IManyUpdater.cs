using Itmo.ObjectOrientedProgramming.Lab3.ResultModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserModel.Interfaces;

public interface IManyUpdater
{
    MessageInteractionResult UpdateAllMessagesStates();
}