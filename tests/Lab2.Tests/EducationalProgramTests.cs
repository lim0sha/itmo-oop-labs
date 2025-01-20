using Itmo.ObjectOrientedProgramming.Lab2.CreditModel.Creators;
using Itmo.ObjectOrientedProgramming.Lab2.EditorModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramModel.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.ExamModel.Creators;
using Itmo.ObjectOrientedProgramming.Lab2.LabworkModel.Creators;
using Itmo.ObjectOrientedProgramming.Lab2.LectureModel.Creators;
using Itmo.ObjectOrientedProgramming.Lab2.RepositoryModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.ResultModel;
using Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;
using Xunit;

namespace Lab2.Tests;

public class EducationalProgramTests
{
    [Fact]
    public void Scenario1()
    {
        var programDirector1 = new User("limosha", 1);
        var programDirector2 = new User("fake_limosha", 2);
        var mainRepository = new Repository<StudyMaterial>("ISy27_1sem_repository");
        var eduProgramBuilder = new EducationalProgramBuilder(programDirector1, "IS_y27_1sem_plan");
        var editor = new Editor();

        EducationalProgram eduProgram = eduProgramBuilder.WithExamSubject("ADS", 1)
            .WithExamSubject("Discrete Math", 1)
            .WithCreditSubject("Software Development Tools", 1)
            .WithCreditSubject("English B2", 1)
            .WithExamSubject("C++ Programming", 1)
            .WithExamSubject("Calculus", 1)
            .BuildProgram();
        mainRepository.AddEducationalProgram(eduProgram);

        Assert.Equal("limosha", programDirector1.Name);
        Assert.Equal("limosha", eduProgram.Director.Name);
        Assert.Equal(1, programDirector1.Id);
        Assert.Equal(eduProgram.Director, programDirector1);
        Assert.Equal("1_theme_exam_subject", mainRepository.FindStudyMaterial(1).Name);
        Assert.Equal(20, mainRepository.FindStudyMaterial(2).Points);
        Assert.Equal(25, mainRepository.FindStudyMaterial(4).Points);
        Assert.Equal(
            editor.EditName(mainRepository.FindStudyMaterial(3), programDirector2, "V++ Programming"),
            new InteractionResult.ModifyingAuthorDiscrepancyFailure(programDirector2));
        Assert.Equal(
            editor.EditDescription(mainRepository.FindStudyMaterial(2), programDirector2, "new labwork_id2 description"),
            new InteractionResult.ModifyingAuthorDiscrepancyFailure(programDirector2));
        Assert.Equal(
            editor.EditDescription(mainRepository.FindStudyMaterial(5), programDirector2, "new lecture_id5 description"),
            new InteractionResult.ModifyingAuthorDiscrepancyFailure(programDirector2));
        Assert.Equal(
            editor.EditDescription(mainRepository.FindStudyMaterial(3), programDirector2, "new exam_id3 description"),
            new InteractionResult.ModifyingAuthorDiscrepancyFailure(programDirector2));
        Assert.Equal(
            editor.EditDescription(mainRepository.FindStudyMaterial(1), programDirector2, "new credit_id1 description"),
            new InteractionResult.ModifyingAuthorDiscrepancyFailure(programDirector2));
    }

    [Fact]
    public void Scenario2()
    {
        var programDirector1 = new User("limosha", 1);
        var mainRepository = new Repository<StudyMaterial>("ITMO_2024_3sem_repository");
        var eduProgramBuilder = new EducationalProgramBuilder(programDirector1, "IS_y27_3sem_plan");
        var subjectDirector = new SubjectDirector(programDirector1);
        var editor = new Editor();

        EducationalProgram eduProgram = eduProgramBuilder.WithExamSubject("Databases", 3)
            .WithExamSubject("Probability theory", 3)
            .WithCreditSubject("English C1", 3)
            .WithCreditSubject("Life safety", 3)
            .BuildProgram();
        mainRepository.AddEducationalProgram(eduProgram);
        StudyMaterial labwork = new LabworkFactory().CreateStudyMaterial(programDirector1, 15, "origin labwork");
        StudyMaterial clonedLabwork = labwork.Clone();
        mainRepository.AddStudyMaterial(clonedLabwork);
        StudyMaterial lecture = new LectureFactory().CreateStudyMaterial(programDirector1, 0, "origin lecture");
        StudyMaterial clonedLecture = lecture.Clone();
        mainRepository.AddStudyMaterial(clonedLecture);
        StudyMaterial exam = new ExamFactory().CreateStudyMaterial(programDirector1, 30, "origin exam");
        StudyMaterial clonedExam = exam.Clone();
        mainRepository.AddStudyMaterial(clonedExam);
        StudyMaterial credit = new CreditFactory().CreateStudyMaterial(programDirector1, 60, "origin credit");
        StudyMaterial clonedCredit = credit.Clone();
        mainRepository.AddStudyMaterial(clonedCredit);
        Subject subject = subjectDirector.BuildExamSubject("C#", 3);
        StudyMaterial clonedSubject = subject.Clone();
        mainRepository.AddStudyMaterial(clonedSubject);

        Assert.Equal("limosha", programDirector1.Name);
        Assert.Equal("limosha", eduProgram.Director.Name);
        Assert.Equal(1, programDirector1.Id);
        Assert.Equal(labwork.Id, clonedLabwork.Id);
        Assert.NotEqual(labwork.Name, clonedLabwork.Name);
        Assert.Equal("origin labwork", labwork.Name);
        Assert.Equal(lecture.Id, clonedLecture.Id);
        Assert.NotEqual(lecture.Name, clonedLecture.Name);
        Assert.Equal("origin lecture", lecture.Name);
        Assert.Equal(exam.Id, clonedExam.Id);
        Assert.NotEqual(exam.Name, clonedExam.Name);
        Assert.Equal("origin exam", exam.Name);
        Assert.Equal(credit.Id, clonedCredit.Id);
        Assert.NotEqual(credit.Name, clonedCredit.Name);
        Assert.Equal("origin credit", credit.Name);
        Assert.Equal(subject.Id, clonedSubject.Id);
        Assert.NotEqual(subject.Name, clonedSubject.Name);
        Assert.Equal("C#", subject.Name);
        Assert.Equal(string.Empty, mainRepository.FindStudyMaterial(5).Description);
        editor.EditDescription(mainRepository.FindStudyMaterial(5), programDirector1, "An advanced C# OOP course in ITMO University");
        Assert.Equal("An advanced C# OOP course in ITMO University", mainRepository.FindStudyMaterial(5).Description);
    }

    [Fact]
    public void Scenario3()
    {
        var programDirector1 = new User("limosha", 1);
        var subjectDirector = new SubjectDirector(programDirector1);
        Subject correctSubject = subjectDirector.BuildExamSubject("correct_subject", 1);
        Subject incorrectSubject = subjectDirector.BuildIncorrectSubject("incorrect_subject", 2);

        Assert.Equal(new InteractionResult.SubjectBuildingSuccess(), subjectDirector.CheckSubjectBuild(correctSubject));
        Assert.Equal(new InteractionResult.RequiredPointsPaucity(99), subjectDirector.CheckSubjectBuild(incorrectSubject));
    }
}