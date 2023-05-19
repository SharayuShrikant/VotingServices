using VotingService.Models;

namespace VotingService.Domain.Interfaces
{
    public interface ISolutionRepository 
    {
        public ICollection<SolutionModel> GetSolutions();

        public SolutionModel GetSolutionById(int solutionid);

        public ICollection<SolutionModel> GetSolutionsByQueryId(int queryId);


        public bool SolutionExist(int id);

        bool CreateSolution(SolutionModel solution);

        bool Save();
    }
}
