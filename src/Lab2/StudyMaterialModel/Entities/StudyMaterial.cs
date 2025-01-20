using Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Entities;

public abstract class StudyMaterial : IStudyMaterial
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool IsCopy { get; set; }

    public int Points { get; protected init; }

    public User? Author { get; init; }

    protected StudyMaterial(int id)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Id cannot be negative");
        }

        Id = id;
    }

    protected StudyMaterial() { }

    public abstract StudyMaterial Clone();
}