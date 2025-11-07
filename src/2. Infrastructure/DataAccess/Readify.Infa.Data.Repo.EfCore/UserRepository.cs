using Microsoft.EntityFrameworkCore;
using Readify.Domain.Core.User.Data;
using Readify.Domain.Core.User.DTOs;
using Readify.Domain.Core.User.Entities;
using Readify.Infa.Db.SqlServer.EfCore.DbContexts;

namespace Readify.Infa.Data.Repo.EfCore;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public int Create(CreateUserDto createUserDto)
    {
        var user = new User()
        {
            FirstName = createUserDto.FirstName,
            LastName = createUserDto.LastName,
            HashedPassword = createUserDto.Password,
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
                .SetProperty(u => u.HashedPassword, newUserInfo.Password)
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
            FirstName = u.FirstName,
            LastName = u.LastName,
            Id = u.Id,
            Role = u.Role,
            UserName = u.UserName,
            ImgUrl = u.ImgUrl,
            IsActive = u.IsActive
        }).ToList();
    }

    public UserDto? GetById(int userId)
    {
        return context.Users.Where(u => u.Id == userId).Select(u => new UserDto()
        {
            FirstName = u.FirstName,
            LastName = u.LastName,
            Id = u.Id,
            ImgUrl = u.ImgUrl,
            IsActive = u.IsActive,
            Role = u.Role,
            UserName = u.UserName
        }).FirstOrDefault();
    }

    public UserDto? GetByUserName(string username)
    {
        return context.Users.Select(u => new UserDto()
        {
            FirstName = u.FirstName,
            LastName = u.LastName,
            Id = u.Id,
            Role = u.Role,
            UserName = u.UserName,
            ImgUrl = u.ImgUrl,
            IsActive = u.IsActive
        }).FirstOrDefault();
    }

    public UserLoginDto? LoginGetByUserName(string username)
    {
        return context.Users.Where(x=>x.UserName == username).Select(u => new UserLoginDto()
        {
            FirstName = u.FirstName,
            LastName = u.LastName,
            Password = u.HashedPassword,
            ImgUrl = u.ImgUrl,
            Id = u.Id,
            Role = u.Role,
            UserName = u.UserName,
            IsActive = u.IsActive
        }).FirstOrDefault();
    }

    public int UpdatePassword(int userId, string newPassword)
    {
       return context.Users.Where(u => u.Id == userId).ExecuteUpdate(setter =>
            setter.SetProperty(u => u.HashedPassword, newPassword));
    }
    public User? GetEntityById(int id)
    {
        return context.Users.FirstOrDefault(u => u.Id == id);
    }
    public void Save()
    {
        context.SaveChanges();
    }

    public int UserCount()
    {
        return context.Users.Count();
    }
}