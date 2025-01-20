using Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Entities;
using File = Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.VisitorModel.Interfaces;

public interface IVisitor
{
    void Visit(File.File fileSystemEntity);

    void Visit(Folder fileSystemEntity);

    string Render();
}