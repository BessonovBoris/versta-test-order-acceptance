using System.Threading.Tasks;
using Application.Models;

namespace Application.Repositories;

public interface IUserRepository
{
    Task<User?> FindByUsernameAsync(string username, string password);
    void Add(User user);
}