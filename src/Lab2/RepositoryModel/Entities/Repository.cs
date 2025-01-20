using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.RepositoryModel.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.SubjectModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryModel.Entities;

public class Repository<T> : IRepository<T> where T : StudyMaterial
{
    private readonly List<StudyMaterial> _dataBase = [];
    private readonly IdGenerator _idGenerator = new IdGenerator();

    public string Name { get; init; }

    public Repository(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentOutOfRangeException(nameof(name), "Name cannot be empty");
        }

        Name = name;
    }

    public T FindStudyMaterial(int id)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Id cannot be negative");
        }

        foreach (T entity in _dataBase)
        {
            if (entity.Id == id)
            {
                return entity;
            }
        }

        throw new KeyNotFoundException($"StudyMaterial with ID {id} not found.");
    }

    public void Delete(int id, User author)
    {
        if (id < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "Id cannot be negative");
        }

        if (author == null)
        {
            throw new ArgumentNullException(nameof(author), "Author cannot be null.");
        }

        T material = FindStudyMaterial(id);
        _dataBase.Remove(material);
    }

    public void AddStudyMaterial(T studyMaterial)
    {
        if (!studyMaterial.IsCopy)
        {
            studyMaterial.Id = _idGenerator.GetNextId();
        }

        _dataBase.Add(studyMaterial);
    }

    public void AddEducationalProgram(EducationalProgram educationalProgram)
    {
        foreach (Subject subject in educationalProgram.Subjects)
        {
            foreach (T studyMaterial in subject.StudyMaterials)
            {
                AddStudyMaterial(studyMaterial);
            }

            AddStudyMaterial(subject);
        }
    }

    private void AddStudyMaterial(Subject studyMaterial)
    {
        if (studyMaterial == null)
        {
            throw new ArgumentNullException(nameof(studyMaterial), "Study material cannot be null.");
        }

        _dataBase.Add(studyMaterial);
    }
}