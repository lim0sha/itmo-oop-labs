using Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramModel.Entities;

public class EducationalProgram : IEntity
{
    public Collection<Subject> Subjects { get; }

    public string Name { get; set; }

    public User Director { get; }

    public int Id { get; set; }

    public bool IsCopy { get; set; }

    public EducationalProgram(User director, string name, Collection<Subject> subjects)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be empty");
        }

        Name = name;
        Director = director ?? throw new ArgumentNullException(nameof(director), "Director cannot be null.");
        Subjects = subjects;
    }
}