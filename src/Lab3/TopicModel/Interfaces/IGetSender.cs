using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.UserModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.TopicModel.Interfaces;

public interface IGetSender
{
    void Send(IGetter recipient, Message message);
}