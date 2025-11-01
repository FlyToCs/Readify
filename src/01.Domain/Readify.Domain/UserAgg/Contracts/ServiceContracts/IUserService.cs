using Readify.Domain._common.Entities;
using Readify.Domain.UserAgg.DTOs;
using Readify.Domain.UserAgg.Enums;

namespace Readify.Domain.UserAgg.Contracts.ServiceContracts;

public interface IUserService
{
    Result<bool> Create(CreateUserDto createUserDto);
    Result<int> Delete(int userId);
    Result<bool> Update(int userId, CreateUserDto newUserInfo);
    Result<bool> UpdateStatus(int userId, bool status);

    Result<List<UserDto>> GetAll();
    Result<UserDto> GetByUserName(string username);
    Result<UserLoginDto> LoginGetByUserName(string username);
    Result<int> UpdatePassword(int userId, string newPassword);
}