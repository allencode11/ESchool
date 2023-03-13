using ESchoolApi.Data;
using ESchoolApi.Interfaces;
using ESchoolApi.Models;

namespace ESchoolApi.Repositories;

public class UsersRepo : IRequest<User>
{
    private readonly ESchoolDBContext _eSchoolDbContext;
    public UsersRepo(ESchoolDBContext dbContext)
    {
        _eSchoolDbContext = dbContext;
    }
    
    public List<User> GetAll()
    {
        return _eSchoolDbContext.Users.ToList();
    }

    public User GetDetails(Guid Id)
    {
        try
        {
            User user = _eSchoolDbContext.Users.Find(Id);

            if (user != null)
            {
                return user;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void AddEntity(User obj)
    {
        try
        {
            _eSchoolDbContext.Users.Add(obj);
            _eSchoolDbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void UpdateEntity(User obj)
    {
        try
        {
            _eSchoolDbContext.Users.Update(obj);
            _eSchoolDbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public void Remove(User obj)
    {
        try
        {
            _eSchoolDbContext.Users.Remove(obj);
            _eSchoolDbContext.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}