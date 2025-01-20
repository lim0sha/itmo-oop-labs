using Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;

public class User : IEntity
{
    public int Id { get; set; }

    public bool IsCopy { get; set; }

    public string Name { get; init; }

    public User(string name, int id)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be empty.");
        }

        Name = name;
        Id = id;
    }
}