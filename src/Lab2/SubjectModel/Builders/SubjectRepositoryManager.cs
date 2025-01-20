using Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Builders;

public class SubjectRepositoryManager
{
    private readonly SubjectDirector _subjectDirector;

    public SubjectRepositoryManager(User director)
    {
        if (director == null)
        {
            throw new ArgumentNullException(nameof(director), "Director cannot be null.");
        }

        _subjectDirector = new SubjectDirector(director);
    }

    public Subject AddExamSubject(string name, int semester)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be empty");
        }

        if (semester < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Semester cannot be less than 1");
        }

        Subject subject = _subjectDirector.BuildExamSubject(name, semester);
        _subjectDirector.CheckSubjectBuild(subject);
        return subject;
    }

    public Subject AddCreditSubject(string name, int semester)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be empty");
        }

        if (semester < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Semester cannot be less than 1");
        }

        Subject subject = _subjectDirector.BuildCreditSubject(name, semester);
        _subjectDirector.CheckSubjectBuild(subject);
        return subject;
    }

    public Subject AddIncorrectSubject(string name, int semester)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be empty");
        }

        if (semester < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Semester cannot be less than 1");
        }

        Subject subject = _subjectDirector.BuildIncorrectSubject(name, semester);
        _subjectDirector.CheckSubjectBuild(subject);
        return subject;
    }
}