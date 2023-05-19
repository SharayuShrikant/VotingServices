using VotingService.Models;

namespace VotingService.Domain.Interfaces
{
    public interface IQueryRepository
    {
        ICollection<QueryModel> GetQueries();

        QueryModel GetQueryById(int id);

        ICollection<QueryModel> GetQueriesByPollId(int pollId);

        public bool QueryExist(int id);

        bool CreateQuery(QueryModel query);

        bool Save();
    }
}
