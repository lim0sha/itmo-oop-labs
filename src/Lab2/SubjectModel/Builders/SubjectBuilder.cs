using Itmo.ObjectOrientedProgramming.Lab2.CreditModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.ExamModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LabworkModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.LectureModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Builders;

public class SubjectBuilder : ISubjectBuilder
{
    private readonly User _subjectAuthor;
    private Subject _subject;

    public SubjectBuilder(
        User subjectAuthor)
    {
        _subjectAuthor = subjectAuthor ?? throw new ArgumentNullException(nameof(subjectAuthor), "Author cannot be null.");
        _subject = new Subject(_subjectAuthor, 0, string.Empty, string.Empty);
    }

    public SubjectBuilder WithLecture(int points, string name)
    {
        if (points < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(points), "Points cannot be negative");
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be empty");
        }

        var lecture = new Lecture(_subjectAuthor, points, name);
        _subject.Add(lecture);
        return this;
    }

    public SubjectBuilder WithLabwork(int points, string name)
    {
        if (points < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(points), "Points cannot be negative");
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be empty");
        }

        var labwork = new Labwork(_subjectAuthor, points, name);
        _subject.Add(labwork);
        return this;
    }

    public SubjectBuilder WithExam(int points, string name)
    {
        if (points < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(points), "Points cannot be negative");
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be empty");
        }

        var exam = new Exam(_subjectAuthor, points, name);
        _subject.Add(exam);
        return this;
    }

    public SubjectBuilder WithCredit(int points, string name)
    {
        if (points < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(points), "Points cannot be negative");
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be empty");
        }

        var credit = new Credit(_subjectAuthor, points, name);
        _subject.Add(credit);
        return this;
    }

    public Subject Build(string name, int semester)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be empty");
        }

        if (semester < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Semester cannot be less than 1");
        }

        _subject.Name = name;
        _subject.Semester = semester;
        Subject result = _subject;
        _subject = new Subject(_subjectAuthor, 0, string.Empty, string.Empty);
        return result;
    }
}