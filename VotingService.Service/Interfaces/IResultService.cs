using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingService.Dto;
using VotingService.Models;

namespace VotingService.Service.Interfaces
{
    public interface IResultService
    {
        public List<int> Get_USerIds_By_SolutionId(int pollId, int queryId, int solutionId);

        public IEnumerable<SolutionGetDto> GetRankedSolution(int queryId, int pollId);

        public IEnumerable<UserPublicGetDto> GetUsersModelBySolutionId(int queryId, int pollId, int solutionId);

        public List<string> GetRankedSolutionNames(int pollId, int queryId);


    }
}
