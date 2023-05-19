using VotingService.Models;

namespace VotingService.Domain.Interfaces
{
    public interface IResponseRepository
    {
        ICollection<ResponseModel> GetResponses();

        public ResponseModel GetResponseById(int reposneid);

        public List<int> Get_USerIds_By_SolutionId(int pollId, int queryId, int solutionId);

        public IEnumerable<SolutionModel> GetRankedSolution(int queryId, int pollId);

        public List<string> GetRankedSolutionNames(int pollId, int queryId);

        public Dictionary<int, List<int>> GetUsersBySolutionAndPoll(int queryId, int pollId);

        public bool ResponseExist(int id);

        bool CreateResponse(ResponseModel response);

        bool Save();

    }
}
