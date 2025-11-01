using Microsoft.EntityFrameworkCore;
using Readify.Domain.UserAgg.Contracts.RepositoryContracts;
using Readify.Domain.UserAgg.DTOs;
using Readify.Domain.UserAgg.Entities;
using Readify.Infrastructure.Persistence;

namespace Readify.Infrastructure.Repository;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public int Create(CreateUserDto createUserDto)
    {
        var user = new User()
        {
            FirstName = createUserDto.FirstName,
            LastName = createUserDto.LastName,
            HashedPassword = createUserDto.HashedPassword,
            ImgUrl = createUserDto.ImgUrl,
            IsActive = false,
            UserName = createUserDto.UserName,
            Role = createUserDto.Role
        };
        context.Add(user);
        context.SaveChanges();
        return user.Id;
    }

    public int Delete(int userId)
    {
        return context.Users.Where(u => u.Id == userId)
            .ExecuteDelete();
    }

    public bool Update(int userId, CreateUserDto newUserInfo)
    {
        var affectedRows = context.Users
            .Where(u => u.Id == userId)
            .ExecuteUpdate(setter => setter
                .SetProperty(u => u.FirstName, newUserInfo.FirstName)
                .SetProperty(u => u.LastName, newUserInfo.LastName)
                .SetProperty(u => u.UserName, newUserInfo.UserName)
                .SetProperty(u => u.HashedPassword, newUserInfo.HashedPassword)
                .SetProperty(u => u.ImgUrl, newUserInfo.ImgUrl)
                .SetProperty(u => u.Role, newUserInfo.Role)
            );

        return affectedRows > 0;
    }


    public bool UpdateStatus(int userId, bool status)
    {
        int affectedRows = context.Users.Where(u => u.Id == userId).ExecuteUpdate(setter =>
            setter.SetProperty(u => u.IsActive, status));
        return affectedRows > 0;
    }

    public bool IsUsernameExist(string username)
    {
        return context.Users.Any(u => u.UserName == username);
    }

    public List<UserDto> GetAll()
    {
        return context.Users.Select(u => new UserDto()
        {
            FullName = $"{u.FirstName} {u.LastName}",
            Id = u.Id,
            Role = u.Role,
            UserName = u.UserName,
            ImgUrl = u.ImgUrl
        }).ToList();
    }

    public UserDto? GetByUserName(string username)
    {
        return context.Users.Select(u => new UserDto()
        {
            FullName = $"{u.FirstName} {u.LastName}",
            Id = u.Id,
            Role = u.Role,
            UserName = u.UserName,
            ImgUrl = u.ImgUrl
        }).FirstOrDefault();
    }

    public UserLoginDto? LoginGetByUserName(string username)
    {
        return context.Users.Select(u => new UserLoginDto()
        {
            FirstName = u.FirstName,
            LastName = u.LastName,
            ImgUrl = u.ImgUrl,
            Id = u.Id,
            Role = u.Role,
            UserName = u.UserName
        }).FirstOrDefault();
    }

    public int UpdatePassword(int userId, string newPassword)
    {
       return context.Users.Where(u => u.Id == userId).ExecuteUpdate(setter =>
            setter.SetProperty(u => u.HashedPassword, newPassword));
    }
}