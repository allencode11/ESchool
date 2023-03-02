namespace ESchoolApi.Models;

public interface IJWTManagerRepository
{
    Token Authenticate(User users);
}