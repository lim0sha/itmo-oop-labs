using Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Interfaces;

public interface IStudyMaterialFactory
{
    StudyMaterial CreateStudyMaterial(User author, int points, string name);
}