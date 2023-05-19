using VotingService.Data;
using VotingService.Domain.Interfaces;
using VotingService.Models;

namespace VotingService.Repository
{
    public class PollQueryRepository : IPollQueryRepository
    {
        private readonly DataContext _context;

        public PollQueryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreatePollQuery(PollQueryModel pollquery)
        {
            _context.PollQueries.Add(pollquery);
            return Save();
        }

        public ICollection<PollQueryModel> GetPollQueries()
        {
            return _context.PollQueries.OrderBy(x => x.PollSessionId).ToList();
        }

        public ICollection<PollQueryModel> GetPollQueriesByPollId(int pollid)
        {
            return _context.PollQueries.Where(x=>x.PollId == pollid).ToList();
        }

        public PollQueryModel GetPollQueryById(int id)
        {
            return _context.PollQueries.Where(x => x.PollSessionId == id).FirstOrDefault();
        }

        public bool PollQueryExist(int id)
        {
            return _context.PollQueries.Where(x => x.PollSessionId == id).Any();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
