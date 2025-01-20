using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Interfaces;

public interface IStudyMaterial : IEntity
{
    string Name { get; set; }

    string Description { get; set; }

    bool IsCopy { get; set; }

    User? Author { get; init; }
}