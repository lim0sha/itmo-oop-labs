using Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Creators;

public abstract class StudyMaterialFactory : IStudyMaterialFactory
{
    public abstract StudyMaterial CreateStudyMaterial(User author, int points, string name);
}