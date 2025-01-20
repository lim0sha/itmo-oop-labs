using Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.VisitorModel.Interfaces;
using System.Text;
using File = Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Entities.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.VisitorModel.Visitors;

public class Visitor : IVisitor, IRenderable
{
    private int _depth;

    private StringBuilder Result { get; set; }

    private string _fileSymbol = "*";

    private string _folderSymbol = "#";

    public Visitor()
    {
        Result = new StringBuilder();
        _depth = 0;
    }

    public void ModifyPathSymbols(string fileSymbol, string folderSymbol)
    {
        _fileSymbol = fileSymbol;
        _folderSymbol = folderSymbol;
    }

    public void Visit(File fileSystemEntity)
    {
        if (fileSystemEntity == null)
        {
            throw new ArgumentNullException(nameof(fileSystemEntity), "File can not be null");
        }

        Result.Append($"{new string('\t', _depth)}{_fileSymbol}{fileSystemEntity.FileName}\n");
    }

    public void Visit(Folder fileSystemEntity)
    {
        if (fileSystemEntity == null)
        {
            throw new ArgumentNullException(nameof(fileSystemEntity), "File can not be null");
        }

        Result.Append($"{new string('\t', _depth)}{_folderSymbol}{fileSystemEntity.FolderName}\n");
        _depth++;
        foreach (IAcceptable file in fileSystemEntity.Files)
        {
            file.Accept(this);
        }

        _depth--;
    }

    public string Render()
    {
        return Result.ToString();
    }
}