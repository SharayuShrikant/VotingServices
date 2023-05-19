using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VotingService.Models;

namespace VotingService.Dto
{
    public class PollQueryGetDto
    {
        public int PollSessionId { get; set; }

        public int PollId { get; set; }

        public int QueryId { get; set; }
    }
}
