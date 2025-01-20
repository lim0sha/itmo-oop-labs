using Itmo.ObjectOrientedProgramming.Lab3.LoggerModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.MessageModel.Properties;
using Itmo.ObjectOrientedProgramming.Lab3.ProxyModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Decorators;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.ResultModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.TextModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.TopicModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.UserModel.Entities;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class MessengerSystemTests
{
    [Fact]
    public void Scenario1()
    {
        const string header = "header1";
        const string body = "msg1";
        const SecurityLevel securityLevel = SecurityLevel.High;
        var mockLogger = new Mock<IMyLogger>();
        var mockRecipient = new Mock<IRecipient>();
        var loggerRecipient = new LoggerDecorator(mockLogger.Object, mockRecipient.Object);
        Message message = new DefaultBuilder()
            .WithHeader(new Txt(header))
            .WithBody(new Txt(body))
            .WithSecurityLevel(securityLevel)
            .Build();
        var topic = new Topic("topic1");

        topic.Send(loggerRecipient, message);

        mockLogger.Verify(x => x.LogMessage(It.Is<Message>(m => m == message)), Times.Once());
        mockRecipient.Verify(x => x.GetMessage(It.Is<Message>(m => m == message)), Times.Once());
    }

    [Fact]
    public void Scenario2()
    {
        const string header = "header2";
        const string body = "msg2";
        const SecurityLevel securityLevel = SecurityLevel.High;
        Message message = new DefaultBuilder()
            .WithHeader(new Txt(header))
            .WithBody(new Txt(body))
            .WithSecurityLevel(securityLevel)
            .Build();
        var user = new User("lim0sha", 2);
        var recipientUser = new RecipientUser("lim0sha_recipient", 2, user);
        var topic = new Topic("topic2");

        topic.Send(recipientUser, message);

        MessageInteractionResult result = recipientUser.User.UpdateMessageState(message);
        Assert.IsType<MessageInteractionResult.MessageStateChanged>(result);
    }

    [Fact]
    public void Scenario3()
    {
        const string header = "header3";
        const string body = "msg3";
        const SecurityLevel securityLevel = SecurityLevel.High;
        Message message = new DefaultBuilder()
            .WithHeader(new Txt(header))
            .WithBody(new Txt(body))
            .WithSecurityLevel(securityLevel)
            .Build();
        var user = new User("lim0sha", 3);
        var recipientUser = new RecipientUser("lim0sha_recipient", 3, user);
        var topic = new Topic("topic3");

        topic.Send(recipientUser, message);
        recipientUser.User.UpdateMessageState(message);

        Assert.Equal(
            new MessageInteractionResult.MessageStateIsNotChanged(),
            recipientUser.User.UpdateMessageState(message));
    }

    [Fact]
    public void Scenario4_WithMoq()
    {
        const string header = "header4";
        const string body = "msg4";
        const SecurityLevel securityLevel = SecurityLevel.Low;
        const SecurityLevel filter = SecurityLevel.High;
        var mockUser = new Mock<IRecipient>();
        var proxy = new FilterRecipientProxy(mockUser.Object, filter, "lim0sha_proxy");
        Message message = new DefaultBuilder()
            .WithHeader(new Txt(header))
            .WithBody(new Txt(body))
            .WithSecurityLevel(securityLevel)
            .Build();
        var topic = new Topic("topic4");

        topic.Send(proxy, message);

        mockUser.Verify(x => x.GetMessage(It.IsAny<Message>()), Times.Never());
    }

    [Fact]
    public void Scenario5_WithMoq()
    {
        const string header = "header5";
        const string body = "msg5";
        const SecurityLevel securityLevel = SecurityLevel.High;
        var mockLogger = new Mock<IMyLogger>();
        var mockRecipient = new Mock<IRecipient>();
        var loggerRecipient = new LoggerDecorator(mockLogger.Object, mockRecipient.Object);
        Message message = new DefaultBuilder()
            .WithHeader(new Txt(header))
            .WithBody(new Txt(body))
            .WithSecurityLevel(securityLevel)
            .Build();
        var topic = new Topic("topic5");

        topic.Send(loggerRecipient, message);

        mockLogger.Verify(x => x.LogMessage(It.Is<Message>(m => m == message)), Times.Once());
        mockRecipient.Verify(x => x.GetMessage(It.Is<Message>(m => m == message)), Times.Once());
    }

    [Fact]
    public void Scenario6_WithMoq()
    {
        const string header = "header6";
        const string body = "msg6";
        const SecurityLevel securityLevel = SecurityLevel.Medium;
        const SecurityLevel filter = SecurityLevel.Low;
        var mockRecipient = new Mock<IRecipient>();
        var messenger = new FilterRecipientProxy(mockRecipient.Object, filter, "lim0sha_proxy");
        Message message = new DefaultBuilder()
            .WithHeader(new Txt(header))
            .WithBody(new Txt(body))
            .WithSecurityLevel(securityLevel)
            .Build();
        var topic = new Topic("topic6");

        topic.Send(messenger, message);

        mockRecipient.Verify(x => x.GetMessage(It.Is<Message>(m => m == message)), Times.Once());
    }

    [Fact]
    public void Scenario7_WithMoq()
    {
        const string header = "header7 - low security level";
        const string body = "msg7 - this is a low security level message";
        const SecurityLevel securityLevel = SecurityLevel.Low;
        const SecurityLevel filter = SecurityLevel.High;
        Message lowSecurityLevelMessage = new DefaultBuilder()
            .WithHeader(new Txt(header))
            .WithBody(new Txt(body))
            .WithSecurityLevel(securityLevel)
            .Build();
        var mockLogger = new Mock<IMyLogger>();
        var mockRecipientWithLowFilter = new Mock<IRecipient>();
        mockRecipientWithLowFilter
            .Setup(x => x.GetMessage(It.Is<Message>(m => m == lowSecurityLevelMessage)))
            .Verifiable();
        var mockRecipientWithHighFilter = new Mock<IRecipient>();
        mockRecipientWithHighFilter
            .Setup(x => x.GetMessage(It.IsAny<Message>()))
            .Verifiable();
        var userSender = new User("lim0sha", 7);
        var loggerRecipient = new LoggerDecorator(mockLogger.Object, mockRecipientWithLowFilter.Object);
        var filterRecipient = new FilterRecipientProxy(mockRecipientWithHighFilter.Object, filter, "lim0sha_proxy");

        userSender.Send(loggerRecipient, lowSecurityLevelMessage);
        userSender.Send(filterRecipient, lowSecurityLevelMessage);

        mockLogger.Verify(x => x.LogMessage(It.Is<Message>(m => m == lowSecurityLevelMessage)), Times.Once());
        mockRecipientWithLowFilter.Verify(
            x => x.GetMessage(It.Is<Message>(m => m == lowSecurityLevelMessage)),
            Times.Once());
        mockRecipientWithHighFilter.Verify(x => x.GetMessage(It.IsAny<Message>()), Times.Never());
    }
}