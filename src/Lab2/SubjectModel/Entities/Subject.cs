using Itmo.ObjectOrientedProgramming.Lab2.CreditModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Entities;

public class Subject : StudyMaterial
{
    public Collection<StudyMaterial> StudyMaterials { get; } = [];

    public int Semester { get; set; }

    public int TotalPoints { get; private set; }

    public Subject(User author, int semester, string name, string description)
    {
        Author = author ?? throw new InvalidOperationException("Author is not initialized.");
        Name = name;
        Semester = semester;
        Description = description;
        TotalPoints = 0;
    }

    public void Add(StudyMaterial studyMaterial)
    {
        StudyMaterials.Add(studyMaterial);
        if (studyMaterial is not Credit)
        {
            TotalPoints += studyMaterial.Points;
        }
    }

    private Subject(int id) : base(id) { }

    public override StudyMaterial Clone()
    {
        var subject = new Subject(Id) { IsCopy = true };
        StudyMaterials.Add(subject);
        return subject;
    }
}