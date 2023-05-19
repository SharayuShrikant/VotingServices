using VotingService.Domain.Interfaces;
using VotingService.Data;
using VotingService.Models;

namespace VotingService.Repository
{
    public class QueryRepository : IQueryRepository
    {
        private readonly DataContext _context;

        public QueryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateQuery(QueryModel query)
        {
            _context.Queries.Add(query);
            return Save();
        }

        public ICollection<QueryModel> GetQueries()
        {
            return _context.Queries.OrderBy(x=>x.QueryId).ToList();
        }

        public ICollection<QueryModel> GetQueriesByPollId(int pollId)
        {
            var queryId = _context.PollQueries.Where(x=>x.PollId == pollId).Select(x=>x.PollId);
            return _context.Queries.Where(x=>queryId.Contains(x.QueryId)).ToList();
        }

        public QueryModel GetQueryById(int queryid)
        {
            return _context.Queries.Where(x=>x.QueryId == queryid).FirstOrDefault();
        }

        public bool QueryExist(int id)
        {
            return _context.Queries.Any(x => x.QueryId == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
