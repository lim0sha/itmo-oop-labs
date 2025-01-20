using Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab4.PathModel.Path;
using Itmo.ObjectOrientedProgramming.Lab4.VisitorModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandModel.Commands;

public class TreeListCommand : CommandBase
{
    private readonly IVisitor _visitor;
    private readonly IPathBuilder _pathBuilder;

    private string TreeDepth { get; }

    public TreeListCommand(string treeDepth, IVisitor visitor, IPathBuilder pathBuilder)
    {
        if (string.IsNullOrEmpty(treeDepth))
        {
            throw new ArgumentException("Depth can not be empty", nameof(treeDepth));
        }

        _pathBuilder = pathBuilder;
        _visitor = visitor;
        TreeDepth = treeDepth;
    }

    public override IList<string> GetParams()
    {
        IList<string> list = [];
        list.Add(TreeDepth);
        return list;
    }

    protected override void Execute(SystemPath path)
    {
        IAcceptable rootFolder = _pathBuilder.BuildFolderStructure(path.Context);
        rootFolder.Accept(_visitor);
        Console.WriteLine(_visitor.Render());
    }
}