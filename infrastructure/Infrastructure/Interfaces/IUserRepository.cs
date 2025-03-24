using core.Entity;
using Infrastructure.Result;

namespace Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<Result<User>> AddAsync(User user);

        Task<Result<User>> GetByEmail(string email);
    }
}
