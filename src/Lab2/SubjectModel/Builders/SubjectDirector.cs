using Itmo.ObjectOrientedProgramming.Lab2.ResultModel;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Builders;

public class SubjectDirector
{
    private readonly SubjectBuilder _builder;

    public SubjectDirector(
        User client)
    {
        if (client == null)
        {
            throw new InvalidOperationException("Client is not initialized.");
        }

        _builder = new SubjectBuilder(client);
    }

    public Subject BuildExamSubject(string name, int semester)
    {
        if (_builder == null)
        {
            throw new InvalidOperationException("Builder is not initialized.");
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be empty");
        }

        if (semester < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Semester cannot be less than 1");
        }

        return _builder.WithLecture(0, "1_theme_exam_subject")
            .WithLabwork(20, "1_theme_lab_exam_subject")
            .WithLecture(0, "2_theme_exam_subject")
            .WithLabwork(25, "2_theme_lab_exam_subject")
            .WithLecture(0, "3_theme_exam_subject")
            .WithLabwork(25, "3_theme_lab_exam_subject")
            .WithExam(30, "final_exam_subject")
            .Build(name, semester);
    }

    public Subject BuildCreditSubject(string name, int semester)
    {
        if (_builder == null)
        {
            throw new InvalidOperationException("Builder is not initialized.");
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be empty");
        }

        if (semester < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Semester cannot be less than 1");
        }

        return _builder.WithLecture(0, "1_theme_credit_subject")
            .WithLabwork(10, "1_theme_lab_credit_subject")
            .WithLecture(0, "2_theme_credit_subject")
            .WithLabwork(15, "2_theme_lab_credit_subject")
            .WithLecture(0, "3_theme_credit_subject")
            .WithLabwork(20, "3_theme_lab_credit_subject")
            .WithLecture(0, "4_theme_credit_subject")
            .WithLabwork(25, "4_theme_lab_credit_subject")
            .WithLecture(0, "5_theme_credit_subject")
            .WithLabwork(30, "5_theme_lab_credit_subject")
            .WithCredit(60, "final_credit_subject")
            .Build(name, semester);
    }

    public Subject BuildIncorrectSubject(string name, int semester)
    {
        if (_builder == null)
        {
            throw new InvalidOperationException("Builder is not initialized.");
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be empty");
        }

        if (semester < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Semester cannot be less than 1");
        }

        return _builder.WithLecture(0, "1_theme_credit_subject")
            .WithLabwork(10, "1_theme_lab_credit_subject")
            .WithLecture(0, "2_theme_credit_subject")
            .WithLabwork(15, "2_theme_lab_credit_subject")
            .WithLecture(0, "3_theme_credit_subject")
            .WithLabwork(20, "3_theme_lab_credit_subject")
            .WithLecture(0, "4_theme_credit_subject")
            .WithLabwork(25, "4_theme_lab_credit_subject")
            .WithLecture(0, "5_theme_credit_subject")
            .WithLabwork(29, "5_theme_lab_credit_subject")
            .WithCredit(60, "final_credit_subject")
            .Build(name, semester);
    }

    public InteractionResult CheckSubjectBuild(Subject subject)
    {
        return _builder == null
            ? throw new InvalidOperationException("Builder is not initialized.")
            : subject.TotalPoints == 100
                ? new InteractionResult.SubjectBuildingSuccess()
                : new InteractionResult.RequiredPointsPaucity(subject.TotalPoints);
    }
}