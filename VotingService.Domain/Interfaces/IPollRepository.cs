using VotingService.Models;

namespace VotingService.Domain.Interfaces
{
    public interface IPollRepository
    {
        ICollection<PollModel> GetPolls();

        PollModel GetPollById(int id);
        
        bool CreatePoll(PollModel poll);

        public bool PollExist(int id);

        bool Save();
    }
}
