using System.ComponentModel.DataAnnotations;

namespace VotingService.Dto
{
    public class SolutionGetDto
    {
        public int SolutionId { get; set; }

        public string SolutionName { get; set; }

        public int QueryId { get; set; }
    }
}
