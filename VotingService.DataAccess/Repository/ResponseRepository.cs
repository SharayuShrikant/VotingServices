using VotingService.Data;
using VotingService.Domain.Interfaces;
using VotingService.Models;

namespace VotingService.Repository
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly DataContext _context;
        public ResponseRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateResponse(ResponseModel response)
        {
            _context.Responses.Add(response);
            return Save();
        }

        public ICollection<ResponseModel> GetResponses()
        {
            return _context.Responses.OrderBy(x => x.QueryId).ToList();
        }

        public ResponseModel GetResponseById(int reponseid)
        {
            return _context.Responses.Where(x => x.ResponseId == reponseid).FirstOrDefault();
        }

        public List<int> Get_USerIds_By_SolutionId(int pollId, int queryId, int solutionId)
        {
            var userIds = _context.Responses
                .Where(r => r.SolutionId == solutionId && r.QueryId == queryId && r.PollId == pollId)
                .Select(r => r.UserId)
                .ToList();

            return userIds;
        }

        public Dictionary<int, List<int>> GetUsersBySolutionAndPoll(int queryId, int pollId)
        {
            var usersBySolution = _context.Responses
                .Where(r => r.QueryId == queryId && r.PollId == pollId)
                .GroupBy(r => r.SolutionId)
                .ToDictionary(g => g.Key, g => g.Select(r => r.UserId).ToList());

            return usersBySolution;
        }

        public IEnumerable<SolutionModel> GetRankedSolution(int queryId, int pollId)
        {
            var solutions = _context.Responses
                    .Where(r => r.PollId == pollId && r.QueryId == queryId)
                    .GroupBy(r => r.Solution)
                    .OrderByDescending(g => g.Count())
                    .Select(g => g.Key);

            return solutions;
            //    var rankedSolutions = _context.Responses
            //        .Where(r => r.QueryId == queryId && r.PollId == pollId)
            //        .GroupBy(r => r.SolutionId)
            //        .OrderByDescending(g => g.Count())
            //        .ThenBy(g => g.Key)
            //        .SelectMany(g => g.Select(r => r.UserId))
            //        .ToList();

            //    return rankedSolutions;
        }

        public List<string> GetRankedSolutionNames(int pollId, int queryId)
        {
            var responseList = _context.Responses
                                        .Where(r => r.PollId == pollId && r.QueryId == queryId)
                                        .ToList();

            var solutionCount = responseList.GroupBy(r => r.SolutionId)
                                            .Select(g => new { SolutionId = g.Key, Count = g.Count() })
                                            .OrderByDescending(g => g.Count);

            var solutionNames = new List<string>();
            foreach (var count in solutionCount)
            {
                var solution = _context.Solutions.Find(count.SolutionId);
                solutionNames.Add(solution.SolutionName);
            }

            return solutionNames;
        }

        public bool ResponseExist(int id)
        {
            return _context.Responses.Where(x => x.ResponseId == id).Any();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
