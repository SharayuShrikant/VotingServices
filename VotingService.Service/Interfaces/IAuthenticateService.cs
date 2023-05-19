using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingService.Dto;
using VotingService.Models;

namespace VotingService.Service.Interfaces
{
    public interface IAuthenticateService
    {
        public UserModel? AuthenticateUser(UserLoginDto user);

        public string GenerateToken();

    }
}
