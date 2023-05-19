
using VotingService.Dto;

namespace VotingService.Service.Interfaces
{
    public interface IPollService
    {
        ICollection<PollGetDto> GetPolls();

        PollGetDto GetPollById(int id);

        bool CreatePoll(PollPostDto poll);
    }
}
