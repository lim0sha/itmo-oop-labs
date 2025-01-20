using Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;

public interface IPathBuilder
{
    IAcceptable BuildFolderStructure(string directoryPath);
}