using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.HandlerModel.Handlers;
using Itmo.ObjectOrientedProgramming.Lab4.HandlerModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.PathModel.Path;
using Itmo.ObjectOrientedProgramming.Lab4.QueryModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.VisitorModel.Visitors;
using Moq;
using Xunit;
using File = Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Entities.File;

namespace Lab4.Tests;

public class FileSystemTests
{
    [Fact]
    public void Scenario1()
    {
        IHandler handleChain = new ConnectHandler()
            .SetNext(new DisconnectHandler())
            .SetNext(new FileHandler())
            .SetNext(new TreeHandler());
        var query = new Query("connect D:// -m local");

        ICommand command = handleChain.Handle(query);

        Assert.NotNull(command);
        Assert.NotEmpty(command.GetParams());
        Assert.Equal("local", command.GetParams()[0]);
        Assert.Equal("D://", command.GetParams()[1]);
    }

    [Fact]
    public void Scenario2()
    {
        IHandler handleChain = new ConnectHandler()
            .SetNext(new DisconnectHandler())
            .SetNext(new FileHandler())
            .SetNext(new TreeHandler());
        var query = new Query("disconnect");

        ICommand command = handleChain.Handle(query);

        Assert.IsType<DisconnectCommand>(command);
    }

    [Fact]
    public void Scenario3()
    {
        IHandler handleChain = new ConnectHandler()
            .SetNext(new DisconnectHandler())
            .SetNext(new FileHandler())
            .SetNext(new TreeHandler());
        var query = new Query("file move D:// param");

        ICommand command = handleChain.Handle(query);

        Assert.NotNull(command);
        Assert.NotEmpty(command.GetParams());
        Assert.Equal("D://", command.GetParams()[0]);
        Assert.Equal("param", command.GetParams()[1]);
    }

    [Fact]
    public void Scenario4()
    {
        var file = new File("example.txt", "This is an example file.");
        var visitor = new Visitor();

        file.Accept(visitor);
        string result = visitor.Render();

        Assert.Contains("*example.txt", result, StringComparison.Ordinal);
    }

    [Fact]
    public void Scenario5()
    {
        var folder = new Folder("Documents");
        var visitor = new Visitor();

        folder.Accept(visitor);
        string result = visitor.Render();

        Assert.Contains("#Documents", result, StringComparison.Ordinal);
    }

    [Fact]
    public void Scenario6()
    {
        var folder = new Folder("Projects");
        folder.AddFile(new File("project1.txt", "Content of project 1"));
        folder.AddFile(new File("project2.txt", "Content of project 2"));
        var visitor = new Visitor();

        folder.Accept(visitor);
        string result = visitor.Render();

        Assert.Contains("#Projects", result, StringComparison.Ordinal);
        Assert.Contains("*project1.txt", result, StringComparison.Ordinal);
        Assert.Contains("*project2.txt", result, StringComparison.Ordinal);
    }

    [Fact]
    public void Scenario7()
    {
        var root = new Folder("Root");
        var subFolder1 = new Folder("SubFolder1");
        var subFolder2 = new Folder("SubFolder2");
        subFolder1.AddFile(new File("file1.txt", "File in SubFolder1"));
        subFolder2.AddFile(new File("file2.txt", "File in SubFolder2"));
        var visitor = new Visitor();

        root.Files.Add(subFolder1);
        root.Files.Add(subFolder2);
        root.Accept(visitor);
        string result = visitor.Render();

        Assert.Contains("#Root", result, StringComparison.Ordinal);
        Assert.Contains("#SubFolder1", result, StringComparison.Ordinal);
        Assert.Contains("*file1.txt", result, StringComparison.Ordinal);
        Assert.Contains("#SubFolder2", result, StringComparison.Ordinal);
        Assert.Contains("*file2.txt", result, StringComparison.Ordinal);
    }

    [Fact]
    public void Scenario8()
    {
        var mockFileSystem = new Mock<IFileSystem>();
        var path = new SystemPath("TestPath");
        var command = new ConnectCommand("local", "TestDirectory");

        command.CanExecute(path);

        Assert.Equal("TestDirectory", path.Context);
        mockFileSystem.VerifyNoOtherCalls();
    }

    [Fact]
    public void Scenario9()
    {
        var root = new Folder("Root");
        var subFolder1 = new Folder("SubFolder1");
        var subFolder2 = new Folder("SubFolder2");
        var subSubFolder = new Folder("SubSubFolder");
        var file1 = new File("file1.txt", "Content of file1");
        var file2 = new File("file2.txt", "Content of file2");
        var file3 = new File("file3.txt", "Content of file3");
        var file4 = new File("file4.txt", "Content of file4");
        var visitor = new Visitor();
        visitor.ModifyPathSymbols("-", "[]");

        subSubFolder.AddFile(file4);
        subFolder1.AddFile(file1);
        subFolder2.AddFile(file2);
        subFolder2.AddFile(file3);
        subFolder2.AddFile(file4);
        subFolder2.AddFile(file3);
        root.AddFile(file1);
        root.AddFile(file2);
        root.AddFile(file4);
        root.AddFile(file2);
        root.AddFile(file1);
        root.AddFile(file2);
        root.AddFile(file3);
        root.AddFile(file4);
        root.AddFile(file3);
        root.Files.Add(subFolder1);
        root.Files.Add(subFolder2);
        subFolder2.Files.Add(subSubFolder);
        root.Accept(visitor);
        string output = visitor.Render();

        Assert.Contains("[]Root", output, StringComparison.Ordinal);
        Assert.Contains("\t[]SubFolder1", output, StringComparison.Ordinal);
        Assert.Contains("\t\t-file1.txt", output, StringComparison.Ordinal);
        Assert.Contains("\t[]SubFolder2", output, StringComparison.Ordinal);
        Assert.Contains("\t\t-file2.txt", output, StringComparison.Ordinal);
        Assert.Contains("\t\t-file3.txt", output, StringComparison.Ordinal);
        Assert.Contains("\t\t-file4.txt", output, StringComparison.Ordinal);
        Assert.Contains("\t\t[]SubSubFolder", output, StringComparison.Ordinal);
        Assert.Contains("\t\t\t-file4.txt", output, StringComparison.Ordinal);
        Assert.True(output.Contains("-file1.txt", StringComparison.Ordinal));
        Assert.True(output.Contains("-file2.txt", StringComparison.Ordinal));
        Assert.True(output.Contains("-file3.txt", StringComparison.Ordinal));
    }
}