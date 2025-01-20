using Itmo.ObjectOrientedProgramming.Lab2.EditorModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ResultModel;
using Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.EditorModel.Entities;

public class AccessChecker : IAccessChecker
{
    public InteractionResult AccessVerification(StudyMaterial studyMaterial, User author)
    {
        if (studyMaterial == null)
        {
            throw new ArgumentNullException(nameof(studyMaterial), "Study material cannot be null.");
        }

        if (author == null)
        {
            throw new ArgumentNullException(nameof(author), "Author cannot be null.");
        }

        if (studyMaterial.Author != author)
        {
            return new InteractionResult.ModifyingAuthorDiscrepancyFailure(author);
        }

        return new InteractionResult.AccessSuccess();
    }
}
