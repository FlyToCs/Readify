using Readify.Domain.Core.User.DTOs;

namespace Readify.Domain.Core.User.Data;

public interface IUserRepository
{
    int Create(CreateUserDto createUserDto);
    int Delete(int userId);
    bool Update(int userId, CreateUserDto newUserInfo);
    bool UpdateStatus(int userId, bool status);

    bool IsUsernameExist(string username);
    List<UserDto> GetAll();
    UserDto? GetById(int userId);
    UserDto? GetByUserName(string username);
    UserLoginDto? LoginGetByUserName(string username);
    int UpdatePassword(int userId, string newPassword);
    Entities.User? GetEntityById(int id);
    void Save();
    int UserCount();

}