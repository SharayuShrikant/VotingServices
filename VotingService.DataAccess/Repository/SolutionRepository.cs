using VotingService.Data;
using VotingService.Domain.Interfaces;
using VotingService.Models;

namespace VotingService.Repository
{
    public class SolutionRepository : ISolutionRepository
    {
        private readonly DataContext _context;

        public SolutionRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateSolution(SolutionModel solution)
        {
            _context.Solutions.Add(solution);
            return Save();
        }

        public SolutionModel GetSolutionById(int solutionid)
        {
            return _context.Solutions.Where(x=>x.SolutionId == solutionid).FirstOrDefault();
        }

        public ICollection<SolutionModel> GetSolutions()
        {
            return _context.Solutions.OrderBy(x=>x.SolutionId).ToList();
        }

        public ICollection<SolutionModel> GetSolutionsByQueryId(int queryId)
        {
            return _context.Solutions.Where(x=>x.QueryId == queryId).ToList();
        }

        public bool Save()
        {
             var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool SolutionExist(int id)
        {
            return _context.Solutions.Any(x=>x.SolutionId == id);
        }
    }
}
