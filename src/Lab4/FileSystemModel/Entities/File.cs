using Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.VisitorModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Entities;

public class File : IRenderable, IModifiable, IAcceptable
{
    public string FileName { get; set; }

    private string Context { get; set; }

    public File(string fileName, string context)
    {
        if (string.IsNullOrEmpty(fileName))
        {
            throw new ArgumentException("Name can not be empty", nameof(fileName));
        }

        FileName = fileName;
        Context = context;
    }

    public string Render()
    {
        return FileName + "\n" + Context;
    }

    public void Modify(string context)
    {
        Context = context;
    }

    public void Accept(IVisitor visitor)
    {
        if (visitor == null)
        {
            throw new ArgumentNullException(nameof(visitor), "Visitor can not be null");
        }

        visitor.Visit(this);
    }
}