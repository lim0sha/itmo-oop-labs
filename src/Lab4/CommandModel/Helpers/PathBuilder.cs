using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Interfaces;
using File = Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Entities.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Helpers;

public class PathBuilder : IPathBuilder
{
    public IAcceptable BuildFolderStructure(string directoryPath)
    {
        if (!Directory.Exists(directoryPath))
        {
            throw new DirectoryNotFoundException($"The directory {directoryPath} does not exist.");
        }

        var currentFolder = new Folder(Path.GetFileName(directoryPath));

        foreach (string filePath in Directory.GetFiles(directoryPath))
        {
            string fileName = Path.GetFileName(filePath);
            string fileContent = System.IO.File.ReadAllText(filePath);
            currentFolder.AddFile(new File(fileName, fileContent));
        }

        foreach (string subDirPath in Directory.GetDirectories(directoryPath))
        {
            IAcceptable subFolder = BuildFolderStructure(subDirPath);
            currentFolder.Files.Add(subFolder);
        }

        return currentFolder;
    }
}