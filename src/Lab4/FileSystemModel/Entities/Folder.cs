using Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.VisitorModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Entities;

public class Folder : IAcceptable
{
    public IList<IAcceptable> Files { get; }

    public string FolderName { get; init; }

    public Folder(string folderName)
    {
        if (string.IsNullOrEmpty(folderName))
        {
            throw new ArgumentException("Name can not be empty", nameof(folderName));
        }

        FolderName = folderName;
        Files = [];
    }

    public void AddFile(File file)
    {
        if (file == null)
        {
            throw new ArgumentNullException(nameof(file), "File can not be null");
        }

        Files.Add(file);
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