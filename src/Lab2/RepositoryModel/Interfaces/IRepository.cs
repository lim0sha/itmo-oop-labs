using Itmo.ObjectOrientedProgramming.Lab2.EducationalProgramModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.StudyMaterialModel.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.UserModel.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryModel.Interfaces;

public interface IRepository<T> where T : StudyMaterial
{
    string Name { get; }

    T FindStudyMaterial(int id);

    void Delete(int id, User author);

    void AddStudyMaterial(T studyMaterial);

    void AddEducationalProgram(EducationalProgram educationalProgram);
}