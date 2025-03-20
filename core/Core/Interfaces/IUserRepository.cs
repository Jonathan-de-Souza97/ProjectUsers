using core.Entity;

namespace core.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
    }
}