using Itmo.ObjectOrientedProgramming.Lab2.EditorModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.ResultModel;
using Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.EditorModel.Entities;

public class Editor : INameEditor, IDescriptionEditor
{
    public InteractionResult EditName(StudyMaterial studyMaterial, User author, string newName)
    {
        if (author == null)
        {
            throw new ArgumentNullException(nameof(author), "Author cannot be null.");
        }

        if (studyMaterial == null)
        {
            throw new ArgumentNullException(nameof(studyMaterial), "Study material cannot be null.");
        }

        if (string.IsNullOrEmpty(newName))
        {
            throw new ArgumentOutOfRangeException(nameof(newName), "Name cannot be empty");
        }

        return EditStudyMaterial(studyMaterial, author, newName, (sm, name) => sm.Name = name);
    }

    public InteractionResult EditDescription(StudyMaterial studyMaterial, User author, string newDescription)
    {
        if (author == null)
        {
            throw new ArgumentNullException(nameof(author), "Author cannot be null.");
        }

        if (studyMaterial == null)
        {
            throw new ArgumentNullException(nameof(studyMaterial), "Study material cannot be null.");
        }

        if (string.IsNullOrEmpty(newDescription))
        {
            throw new ArgumentOutOfRangeException(nameof(newDescription), "Description cannot be empty");
        }

        return EditStudyMaterial(studyMaterial, author, newDescription, (sm, description) => sm.Description = description);
    }

    private InteractionResult EditStudyMaterial(StudyMaterial studyMaterial, User author, string newValue, Action<StudyMaterial, string> editAction)
    {
        if (author == null)
        {
            throw new ArgumentNullException(nameof(author), "Author cannot be null.");
        }

        if (studyMaterial == null)
        {
            throw new ArgumentNullException(nameof(studyMaterial), "Study material cannot be null.");
        }

        if (string.IsNullOrEmpty(newValue))
        {
            throw new ArgumentOutOfRangeException(nameof(newValue), "New string parameter cannot be empty");
        }

        var accessChecker = new AccessChecker();
        InteractionResult verificationResult = accessChecker.AccessVerification(studyMaterial, author);
        if (verificationResult is InteractionResult.AccessSuccess)
        {
            editAction(studyMaterial, newValue);
        }

        return verificationResult;
    }
}