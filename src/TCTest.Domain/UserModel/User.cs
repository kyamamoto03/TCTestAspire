using TCTest.Domain.SeedOfWork;

namespace TCTest.Domain.UserModel;

public class User : IAggregateRoot
{
    public string UserId { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }

    public User(string userId, string name, int age)
    {
        UserId = userId;
        Name = name;
        Age = age;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void SetAge(int age)
    {
        Age = age;
    }
}