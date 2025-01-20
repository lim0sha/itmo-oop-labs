using Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Interfaces;

public interface IBuilder
{
    Subject Build(string name, int semester);
}