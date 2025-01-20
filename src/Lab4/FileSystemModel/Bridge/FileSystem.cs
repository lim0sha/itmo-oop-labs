using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.PathModel.Path;
using Itmo.ObjectOrientedProgramming.Lab4.VisitorModel.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Bridge;

public class FileSystem : IFileSystem
{
    public string FsName { get; init; }

    public FileSystem(string fsName)
    {
        FsName = fsName;
    }

    public void FsConnect(SystemPath path, string condition, string address)
    {
        var connectCommand = new ConnectCommand(condition, address);
        connectCommand.CanExecute(path);
    }

    public void FsCopy(SystemPath path, string inPath, string finPath)
    {
        var copyCommand = new CopyCommand(inPath, finPath);
        copyCommand.CanExecute(path);
    }

    public void FsDelete(SystemPath path, string address)
    {
        var deleteCommand = new DeleteCommand(address);
        deleteCommand.CanExecute(path);
    }

    public void FsDisconnect(SystemPath path, string address)
    {
        var disconnectCommand = new DisconnectCommand(address);
        disconnectCommand.CanExecute(path);
    }

    public void FsMove(SystemPath path, string inPath, string finPath)
    {
        var moveCommand = new MoveCommand(inPath, finPath);
        moveCommand.CanExecute(path);
    }

    public void FsRename(SystemPath path, string address, string newName)
    {
        var renameCommand = new RenameCommand(address, newName);
        renameCommand.CanExecute(path);
    }

    public void FsShow(SystemPath path, string condition, string address)
    {
        var showCommand = new ShowCommand(condition, address);
        showCommand.CanExecute(path);
    }

    public void FsTreeGoTo(SystemPath path, string address)
    {
        var treeGoToCommand = new TreeGoToCommand(address);
        treeGoToCommand.CanExecute(path);
    }

    public void FsList(SystemPath path, Visitor visitor, IPathBuilder pathBuilder)
    {
        var treeListCommand = new TreeListCommand("-1", visitor, pathBuilder);
        treeListCommand.CanExecute(path);
    }
}