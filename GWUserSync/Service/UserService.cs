using AutoMapper;
using GWUserSync.Data;
using GWUserSync.Models;
using GWUserSync.Repository;

namespace GWUserSync.Service;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<int> AddUserAsync(UserModel userModel)
    {
        var user = _mapper.Map<User>(userModel);
        await _userRepository.AddUserAsync(user);
        return user.Id;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        if (user != null)
        {
            return await _userRepository.DeleteUserAsync(user);
        }
        else
            return false;
    }

    public async Task<List<UserModel>> GetAllUsersAsync()
    {
        return _mapper.Map<List<UserModel>>(await _userRepository.GetAllUsersAsync());
    }

    public async Task<UserModel> GetUserByIdAsync(int id)
    {
        return _mapper.Map<UserModel>(await _userRepository.GetUserByIdAsync(id));
    }

    public async Task<bool> UpdateUserAsync(UserModel userModel)
    {
        var user = await _userRepository.GetUserByIdAsync(userModel.Id);
        if (user != null)
        {
            user = _mapper.Map(userModel, user);
            return await _userRepository.UpdateUserAsync(user);
        }
        return false;
    }
}