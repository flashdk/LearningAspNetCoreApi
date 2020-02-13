using ComedyEvents.Domain.Dtos;
using ComedyEvents.Domain.Models;
using ComedyEvents.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ComedyEvents.Services
{
    public interface IUserService
    {
        Task<BaseResponseDto<UserDto>> CreateUser(User user);
        Task<BaseResponseDto<UserDto>> GetUserById(Guid userId);
        Task<BaseResponseDto<IEnumerable<UserDto>>> GetUsers();
        Task<BaseResponseDto<UserDto>> UpDateUser(Guid userId, User user);
        Task<BaseResponseDto<UserDto>> DeleteUser(Guid userId);
        Task<BaseResponseDto<UserDto>> ConnectUser(string username, string password);
    }
}
