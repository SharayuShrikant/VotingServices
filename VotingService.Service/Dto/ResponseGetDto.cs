using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VotingService.Models;

namespace VotingService.Dto
{
    public class ResponseGetDto
    {
        public int ResponseId { get; set; }

        public int PollId { get; set; }


        public int QueryId { get; set; }

        public int SolutionId { get; set; }

        public int UserId { get; set; }
    }
}
