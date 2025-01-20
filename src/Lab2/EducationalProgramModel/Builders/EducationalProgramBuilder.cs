using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramModel.Builders;

public class EducationalProgramBuilder : IExamSubjectBuilder, ICreditSubjectBuilder, IEducationalProgramRetriever
{
    private readonly SubjectRepositoryManager _subjectRepositoryManager;
    private readonly User _director;
    private readonly string _programName;

    private readonly Collection<Subject> _subjects = [];

    public EducationalProgramBuilder(User director, string programName)
    {
        if (string.IsNullOrEmpty(programName))
        {
            throw new ArgumentOutOfRangeException(nameof(programName), "Program name cannot be empty");
        }

        _director = director ?? throw new ArgumentNullException(nameof(director), "Director cannot be null.");
        _programName = programName;
        _subjectRepositoryManager = new SubjectRepositoryManager(director);
    }

    public EducationalProgramBuilder WithExamSubject(string name, int semester)
    {
        if (semester < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(semester), "Semester numbering begins with 1 or greater");
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be empty");
        }

        _subjects.Add(_subjectRepositoryManager.AddExamSubject(name, semester));
        return this;
    }

    public EducationalProgramBuilder WithCreditSubject(string name, int semester)
    {
        if (semester < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(semester), "Semester numbering begins with 1 or greater");
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be empty");
        }

        _subjects.Add(_subjectRepositoryManager.AddCreditSubject(name, semester));
        return this;
    }

    public EducationalProgramBuilder WithIncorrectSubject(string name, int semester)
    {
        if (semester < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(semester), "Semester numbering begins with 1 or greater");
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be empty");
        }

        _subjects.Add(_subjectRepositoryManager.AddIncorrectSubject(name, semester));
        return this;
    }

    public EducationalProgram BuildProgram()
    {
        return new EducationalProgram(_director, _programName, _subjects);
    }
}