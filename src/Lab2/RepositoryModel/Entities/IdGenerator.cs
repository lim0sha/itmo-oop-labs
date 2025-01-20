namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryModel.Entities;

public class IdGenerator
{
    private int _currentId;

    public IdGenerator(int startId = 0)
    {
        _currentId = startId;
    }

    public int GetNextId()
    {
        return ++_currentId;
    }
}
