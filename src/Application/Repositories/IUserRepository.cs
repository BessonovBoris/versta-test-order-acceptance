using Application.Models;

namespace Application.Repositories;

public interface IUserRepository
{
    Task<User?> FindByUsernameAsync(string username, string password);
}