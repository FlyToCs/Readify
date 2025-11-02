using Readify.Domain._common.Entities;
using Readify.Domain.FileAgg;
using Readify.Domain.UserAgg.Contracts.RepositoryContracts;
using Readify.Domain.UserAgg.Contracts.ServiceContracts;
using Readify.Domain.UserAgg.DTOs;
using Readify.Framework;
using System.Text.RegularExpressions;

namespace Readify.Services;

public class UserService(IUserRepository userRepository, IFileService fileService) : IUserService

{
    public Result<bool> Create(CreateUserDto createUserDto)
    {
       
        if (string.IsNullOrWhiteSpace(createUserDto.FirstName) ||
            string.IsNullOrWhiteSpace(createUserDto.LastName) ||
            string.IsNullOrWhiteSpace(createUserDto.UserName) ||
            string.IsNullOrWhiteSpace(createUserDto.Password))
            return Result<bool>.Failure("تمام فیلدهای ضروری باید پر شوند.");

        if (createUserDto.UserName.Length < 4)
            return Result<bool>.Failure("نام کاربری باید حداقل ۴ کاراکتر باشد.");

        if (createUserDto.Password.Length < 8)
            return Result<bool>.Failure("رمز عبور باید حداقل ۸ کاراکتر باشد.");


        createUserDto.UserName = createUserDto.UserName.Trim().ToLower();
        createUserDto.FirstName = createUserDto.FirstName.Trim();
        createUserDto.LastName = createUserDto.LastName.Trim();


        if (userRepository.IsUsernameExist(createUserDto.UserName))
            return Result<bool>.Failure("نام کاربری قبلاً ثبت شده است.");

        
        if (createUserDto.ImgFile != null)
            createUserDto.ImgUrl = fileService.Upload(createUserDto.ImgFile, "Users");
        else
            createUserDto.ImgUrl = "/Files/Users/default-profile.jpg";

    
        createUserDto.Password = PasswordHasherSha256.HashPassword(createUserDto.Password);

        userRepository.Create(createUserDto);

        return Result<bool>.Success(message: "کاربر با موفقیت ثبت شد");
    }


    public Result<UserDto> Login(string userName, string password)
    {
        if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            return Result<UserDto>.Failure("نام کاربری و رمز عبور الزامی است.");

        userName = userName.Trim().ToLower();
        var user = userRepository.LoginGetByUserName(userName);

        if (user == null)
            return Result<UserDto>.Failure("نام کاربری یا رمز عبور اشتباه است.");

        if (!PasswordHasherSha256.VerifyPassword(password, user.Password))
            return Result<UserDto>.Failure("نام کاربری یا رمز عبور اشتباه است.");

        if (!user.IsActive)
            return Result<UserDto>.Failure("کاربر فعال نیست.");

        var userDto = new UserDto
        {
            Id = user.Id,
            FullName = $"{user.FirstName} {user.LastName}",
            ImgUrl = user.ImgUrl,
            Role = user.Role,
            UserName = user.UserName
        };

        return Result<UserDto>.Success("ورود با موفقیت انجام شد", userDto);
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