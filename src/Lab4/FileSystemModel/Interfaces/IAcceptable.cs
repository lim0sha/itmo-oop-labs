using Itmo.ObjectOrientedProgramming.Lab4.VisitorModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Interfaces;

public interface IAcceptable
{
    void Accept(IVisitor visitor);
}