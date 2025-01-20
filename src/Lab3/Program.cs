using Itmo.ObjectOrientedProgramming.Lab3.LoggerModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Properties;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Decorators;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.RenderableModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.TextModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.TopicModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.UserModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Program
{
    public static void Main()
    {
        const string header1 = "ColoredHeader";
        const string body1 = "ColoredMessage";

        const string header2 = "Header";
        const string body2 = "Message";
        const SecurityLevel securityLevel = SecurityLevel.Medium;

        var logger = new MyLogger("Logger1");
        var user = new User("user1", 1);
        var recipientUser = new RecipientUser("lim0sha_recipient", 1, user);

        Message coloredMessage = new DefaultBuilder()
            .WithHeader(new Txt(header1).AddModifier(new ColorSetter(ConsoleColor.Green)))
            .WithBody(new Txt(body1))
            .WithSecurityLevel(securityLevel)
            .Build();

        Message defaultMessage = new DefaultBuilder()
            .WithHeader(new Txt(header2))
            .WithBody(new Txt(body2))
            .WithSecurityLevel(securityLevel)
            .Build();

        var userDecorator = new LoggerDecorator(logger, recipientUser);
        var topic = new Topic("topic1");

        Console.WriteLine("Sending colored message:");
        topic.Send(userDecorator, coloredMessage);

        Console.WriteLine("Sending plain message:");
        topic.Send(userDecorator, defaultMessage);

        const string header = "header1";
        const string body = "msg1";
        const SecurityLevel newSecurityLevel = SecurityLevel.High;

        var myLogger = new MyLogger("logger1");
        var myUser = new User("myUser", 1);
        var myRecipientUser = new RecipientUser("lim0sha", 1, myUser);

        Message message = new DefaultBuilder()
            .WithHeader(new Txt(header))
            .WithBody(new Txt(body))
            .WithSecurityLevel(newSecurityLevel)
            .Build();

        var newUserDecorator = new LoggerDecorator(myLogger, myRecipientUser);
        var newTopic = new Topic("topic1");
        var fileSaver = new FileSaverMock("messages.txt");

        newTopic.Send(newUserDecorator, message);
        fileSaver.SaveMessageToFile(message.Header, isColored: false);
        fileSaver.SaveMessageToFile(message.Body, isColored: true, color: ConsoleColor.Green);
        Console.WriteLine("Messages have been saved to file.");
    }
}