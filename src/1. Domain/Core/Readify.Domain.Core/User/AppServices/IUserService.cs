
using Readify.Domain.Core._common.Entities;
using Readify.Domain.Core.User.DTOs;


namespace Readify.Domain.Core.User.AppServices;

public interface IUserService
{
    Result<bool> Create(CreateUserDto createUserDto);
    Result<UserDto> Login(string userName, string password);
    Result<int> Delete(int userId);
    Result<bool> Update(int userId, CreateUserDto newUserInfo);
    Result<bool> UpdateStatus(int userId, bool status);
    Result<UserDto> GetById(int userId);

    Result<List<UserDto>> GetAll();
    Result<UserDto> GetByUserName(string username);
    Result<UserLoginDto> LoginGetByUserName(string username);
    Result<int> UpdatePassword(int userId, string newPassword);
    int UserCount();
}