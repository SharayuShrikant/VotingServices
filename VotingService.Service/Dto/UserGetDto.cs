using System.ComponentModel.DataAnnotations;

namespace VotingService.Dto
{
    public class UserGetDto
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
