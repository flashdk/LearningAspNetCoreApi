using ComedyEvents.Domain.Dtos;
using ComedyEvents.Domain.Models;
using ComedyEvents.Services.Helpers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ComedyEvents.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IRepository<User> _userRepository;

        private readonly AppSettings _appSettings;

        public UserService(ILogger<UserService> logger, IRepository<User> userRepository, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        public async Task<BaseResponseDto<UserDto>> ConnectUser(string username, string password)
        {
            BaseResponseDto<UserDto> getIdentificationResponse = new BaseResponseDto<UserDto>();

            try
            {
                User user = await _userRepository.Identification(username, password);

                if (user == null)
                    return null;

                getIdentificationResponse.Data = new UserDto
                {
                    Id = user.Id,
                    Name =user.Name,
                    FirstName = user.FirstName,
                    Age = user.Age,
                };

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                getIdentificationResponse.Data.Token = tokenHandler.WriteToken(token);

                return getIdentificationResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                getIdentificationResponse.Errors.Add(ex.Message);
            }
            return getIdentificationResponse;
        }

        public Task<BaseResponseDto<UserDto>> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponseDto<UserDto>> DeleteUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponseDto<UserDto>> GetUserById(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponseDto<IEnumerable<UserDto>>> GetUsers()
        {
            BaseResponseDto<IEnumerable<UserDto>> getUserResponse = new BaseResponseDto<IEnumerable<UserDto>>();
            try
            {
                getUserResponse.Data =
                  (await _userRepository.GetAllAsync()).Select(u => new UserDto()
                  {
                      Id = u.Id,
                      Name = u.Name,
                      FirstName = u.FirstName,
                      Age = u.Age,
                      UserName = u.UserName,
                      CreatedAt = u.CreatedAt.Value,
                      ModifiedAt = u.ModifiedAt.Value,
                  });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                getUserResponse.Errors.Add(ex.Message);
            }

            return getUserResponse;
        }

        public Task<BaseResponseDto<UserDto>> UpDateUser(Guid userId, User user)
        {
            throw new NotImplementedException();
        }
    }
}
