using core.Entity;
using Infrastructure.Result;

namespace application.Interfaces
{
    public interface IUserRepository
    {
        Task<Result<User>> AddAsync(User user);
    }
}