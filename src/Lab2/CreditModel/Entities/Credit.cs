using Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.CreditModel.Entities;

public class Credit : StudyMaterial
{
    public Credit(User author, int points, string name)
    {
        if (points < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(points), "Points cannot be negative");
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be empty");
        }

        Author = author ?? throw new ArgumentNullException(nameof(author), "Author cannot be null.");
        Points = points;
        Name = name;
    }

    private Credit(int id) : base(id)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Id cannot be negative");
        }
    }

    public override StudyMaterial Clone()
    {
        var credit = new Credit(Id) { IsCopy = true };
        return credit;
    }
}