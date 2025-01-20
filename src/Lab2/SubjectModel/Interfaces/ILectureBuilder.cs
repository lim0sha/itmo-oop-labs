using Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Interfaces;

public interface ILectureBuilder
{
    SubjectBuilder WithLecture(int points, string name);
}