using VotingService.Dto;
using VotingService.Models;

namespace VotingService.Service.Interfaces
{
    public interface IQueryService
    {
        ICollection<QueryGetDto> GetQueries();

        QueryGetDto GetQueryById(int id);

        ICollection<QueryGetDto> GetQueriesByPollId(int pollId);

        bool CreateQuery(QueryPostDto queryDto);
    }
}
