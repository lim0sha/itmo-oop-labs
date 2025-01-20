using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.PathModel.Path;
using Itmo.ObjectOrientedProgramming.Lab4.VisitorModel.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Interfaces;

public interface IFileSystem
{
    public void FsConnect(SystemPath path, string condition, string address);

    public void FsCopy(SystemPath path, string inPath, string finPath);

    public void FsDelete(SystemPath path, string address);

    public void FsDisconnect(SystemPath path, string address);

    public void FsMove(SystemPath path, string inPath, string finPath);

    public void FsRename(SystemPath path, string address, string newName);

    public void FsShow(SystemPath path, string condition, string address);

    public void FsTreeGoTo(SystemPath path, string address);

    void FsList(SystemPath path, Visitor visitor, IPathBuilder pathBuilder);
}