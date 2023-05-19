using VotingService.Models;

namespace VotingService.Domain.Interfaces
{
    public interface IPollQueryRepository
    {
        ICollection<PollQueryModel> GetPollQueries();

        PollQueryModel GetPollQueryById(int queryId);

        ICollection<PollQueryModel> GetPollQueriesByPollId(int pollid);

        bool CreatePollQuery(PollQueryModel pollquery);

        public bool PollQueryExist(int id);

        bool Save();



    }
}
