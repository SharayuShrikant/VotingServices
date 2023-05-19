using VotingService.Data;
using VotingService.Domain.Interfaces;
using VotingService.Models;

namespace VotingService.Repository
{
    public class PollRepository : IPollRepository
    {
        private readonly DataContext _context;

        public PollRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreatePoll(PollModel poll)
        {
            _context.Polls.Add(poll);
            return Save();
        }

        public PollModel GetPollById(int id)
        {
            return _context.Polls.Where(x => x.PollId == id).FirstOrDefault();
        }

        public ICollection<PollModel> GetPolls()
        {
            return _context.Polls.OrderBy(x=>x.PollId).ToList();
        }

        public bool PollExist(int id)
        {
            return _context.Polls.Any(x => x.PollId == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
