using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingService.Domain.Interfaces;
using VotingService.Dto;
using VotingService.Models;
using VotingService.Service.Interfaces;

namespace VotingService.Service.Repository
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private IConfiguration _config;

        public AuthenticateService(IUserRepository userRepository, IMapper mapper, IConfiguration config)
        {
            _mapper = mapper;
            _config = config;
            _userRepository = userRepository;
        }
        public UserModel? AuthenticateUser(UserLoginDto user)
        {
            var _user = (_userRepository.GetUserByUsername(user.Username));
            var passwordHasher = new PasswordHasher<UserLoginDto>();

            var success = (passwordHasher.VerifyHashedPassword(null, _user.Password, user.Password) == PasswordVerificationResult.Success);
            if (_user == null)
            {
                return null;
            }
            if (!success)
            {
                return null;
            }
            return _user;
        }

        public string GenerateToken()
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,
                 expires: DateTime.Now.AddMinutes(10),
                 signingCredentials: credentials
                 );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
