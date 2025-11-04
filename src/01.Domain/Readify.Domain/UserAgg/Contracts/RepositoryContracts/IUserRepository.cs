using Readify.Domain.UserAgg.DTOs;
using Readify.Domain.UserAgg.Entities;

namespace Readify.Domain.UserAgg.Contracts.RepositoryContracts;

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
    User? GetEntityById(int id);
    void Save();



}