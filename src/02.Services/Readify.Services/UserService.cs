using Readify.Domain._common.Entities;
using Readify.Domain.UserAgg.Contracts.RepositoryContracts;
using Readify.Domain.UserAgg.Contracts.ServiceContracts;
using Readify.Domain.UserAgg.DTOs;

namespace Readify.Services;

public class UserService(IUserRepository userRepository) : IUserService

{
    public Result<bool> Create(CreateUserDto createUserDto)
    {
        userRepository.Create(createUserDto);
        return Result<bool>.Success(message:"کابر با موفقیت رجیستر شد");
    }

    public Result<int> Delete(int userId)
    {
        var result = userRepository.Delete(userId);
        return Result<int>.Success("",result);
    }

    public Result<bool> Update(int userId, CreateUserDto newUserInfo)
    {
        var result = userRepository.Update(userId, newUserInfo);
        return Result<bool>.Success("", result);
    }

    public Result<bool> UpdateStatus(int userId, bool status)
    {
        var result = userRepository.UpdateStatus(userId, status);
        return Result<bool>.Success("", result);
    }

    public Result<List<UserDto>> GetAll()
    {
        var result = userRepository.GetAll();
        return Result<List<UserDto>>.Success("", result);
    }

    public Result<UserDto> GetByUserName(string username)
    {
        var result = userRepository.GetByUserName(username);
        if (result is null)
        {
            return Result<UserDto>.Failure("کاربر یافت نشد", result);
        }
        else
        {
            return Result<UserDto>.Success("", result);

        }
    }

    public Result<UserLoginDto> LoginGetByUserName(string username)
    {
        var result = userRepository.LoginGetByUserName(username);
        if (result is null)
        {
            return Result<UserLoginDto>.Failure("کاربر یافت نشد", result);
        }
        else
        {
            return Result<UserLoginDto>.Success("", result);

        }
    }

    public Result<int> UpdatePassword(int userId, string newPassword)
    {
        var result = userRepository.UpdatePassword(userId, newPassword);
        return Result<int>.Success("", result);
    }
}