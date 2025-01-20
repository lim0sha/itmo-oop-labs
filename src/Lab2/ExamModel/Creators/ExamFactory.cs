using Itmo.ObjectOrientedProgramming.Lab2.ExamModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Creators;
using Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.ExamModel.Creators;

public class ExamFactory : StudyMaterialFactory
{
    public override StudyMaterial CreateStudyMaterial(User author, int points, string name)
    {
        if (author == null)
        {
            throw new ArgumentNullException(nameof(author), "Author cannot be null.");
        }

        if (points < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(points), "Points must be greater than zero.");
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be empty");
        }

        return new Exam(author, points, name);
    }
}