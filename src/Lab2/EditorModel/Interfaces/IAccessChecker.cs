using Itmo.ObjectOrientedProgramming.Lab2.ResultModel;
using Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.EditorModel.Interfaces;

public interface IAccessChecker
{
    InteractionResult AccessVerification(StudyMaterial studyMaterial, User author);
}