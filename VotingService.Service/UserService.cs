using AutoMapper;
using VotingService.Domain.Interfaces;
using VotingService.Dto;
using VotingService.Models;
using VotingService.Service.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace VotingService.Service.Repository
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRpository, IMapper mapper)
        {
            _userRepository = userRpository;
            _mapper = mapper;
        }

        public bool CreateUser(UserLoginDto usercreate)
        {
            var passwordHasher = new PasswordHasher<UserLoginDto>();
            usercreate.Password = passwordHasher.HashPassword(null, usercreate.Password);

            var user = _userRepository.GetUser().Where(c => c.Username.ToLower() == usercreate.Username.ToLower() &&
            c.Password == usercreate.Password).FirstOrDefault();

            if (user != null)
            {
                return false; // Query already exists
            }

            var userMap = _mapper.Map<UserModel>(usercreate);
            userMap.Role = "employee";

            return _userRepository.CreateUser(userMap);
        }

        public ICollection<UserGetDto> GetUser()
        {
            return _mapper.Map<List<UserGetDto>>(_userRepository.GetUser());
        }

        public UserGetDto GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public UserGetDto GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public ICollection<UserGetDto> GetUsersByResponse(int responseId, int pollId, int queryId)
        {
            throw new NotImplementedException();
        }
    }
}
