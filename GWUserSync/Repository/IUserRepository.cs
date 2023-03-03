using GWUserSync.Data;

namespace GWUserSync.Repository;

public interface IUserRepository
{
    Task<int> AddUserAsync(User newUser);
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<bool> UpdateUserAsync(User newUser);
    Task<bool> DeleteUserAsync(User user);
}
