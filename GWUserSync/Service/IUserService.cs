using GWUserSync.Models;

namespace GWUserSync.Service;

public interface IUserService
{
    Task<List<UserModel>> GetAllUsersAsync();
    Task<UserModel> GetUserByIdAsync(int id);
    Task<int> AddUserAsync(UserModel user);
    Task<bool> UpdateUserAsync(UserModel user);
    Task<bool> DeleteUserAsync(int id);
}
