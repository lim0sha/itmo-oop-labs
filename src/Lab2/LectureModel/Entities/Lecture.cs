using Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectureModel.Entities;

public class Lecture : StudyMaterial
{
    public string Content { get; set; } = string.Empty;

    public Lecture(User author, int points, string name)
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

    private Lecture(int id) : base(id)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Id cannot be negative");
        }
    }

    public override StudyMaterial Clone()
    {
        var lecture = new Lecture(Id) { IsCopy = true };
        return lecture;
    }
}