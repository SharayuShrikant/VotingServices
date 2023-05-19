using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingService.Dto;
using VotingService.Models;

namespace VotingService.Service.Interfaces
{
    public interface ISolutionService
    {
        public ICollection<SolutionGetDto> GetSolutions();

        public SolutionGetDto GetSolutionById(int solutionid);

        public ICollection<SolutionGetDto> GetSolutionsByQueryId(int queryId);

        bool CreateSolution(SolutionPostDto solutioncreate);
    }
}
