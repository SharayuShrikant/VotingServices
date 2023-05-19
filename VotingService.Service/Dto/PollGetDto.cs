using System.ComponentModel.DataAnnotations;

namespace VotingService.Dto
{
    public class PollGetDto
    {
        public int PollId { get; set; }

        public string PollName { get; set; }

    }
}
