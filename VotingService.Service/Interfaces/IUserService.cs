using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingService.Dto;
using VotingService.Models;

namespace VotingService.Service.Interfaces
{
    public interface IUserService
    {
        ICollection<UserGetDto> GetUser();

        UserGetDto GetUserById(int id);

        UserGetDto GetUserByUsername(string username);

        public ICollection<UserGetDto> GetUsersByResponse(int responseId, int pollId, int queryId);

        bool CreateUser(UserLoginDto usercreate);
    }
}
