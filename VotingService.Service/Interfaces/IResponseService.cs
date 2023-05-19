using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingService.Dto;
using VotingService.Models;

namespace VotingService.Service.Interfaces
{
    public interface IResponseService
    {
        ICollection<ResponseGetDto> GetResponses();

        public ResponseGetDto GetResponseById(int reposneid);

        public List<int> Get_USerIds_By_SolutionId(int pollId, int queryId, int solutionId);

        public IEnumerable<SolutionModel> GetRankedSolution(int queryId, int pollId);

        public List<string> GetRankedSolutionNames(int pollId, int queryId);

        public Dictionary<int, List<int>> GetUsersBySolutionAndPoll(int queryId, int pollId);

        bool CreateResponse(ResponsePostDto response);
    }
}
