using Itmo.ObjectOrientedProgramming.Lab2.ResultModel;
using Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.EditorModel.Interfaces;

public interface IDescriptionEditor
{
    InteractionResult EditDescription(StudyMaterial studyMaterial, User author, string newDescription);
}