using VotingService.Data;
using VotingService.Domain.Interfaces;
using VotingService.Models;

namespace VotingService.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateUser(UserModel user)
        {
            _context.Users.Add(user);
            return Save();
        }

        public ICollection<UserModel> GetUser()
        {
            return _context.Users.OrderBy(x=>x.UserId).ToList();
        }

        public UserModel GetUserById(int id)
        {
            return _context.Users.Where(x => x.UserId == id).FirstOrDefault();
        }

        public UserModel GetUserByUsername(string username)
        {
            return _context.Users.Where(x => x.Username.ToLower() == username.ToLower()).FirstOrDefault();
        }

        public ICollection<UserModel> GetUsersByResponse(int responseId , int pollId , int queryId)
        {
            var userIds = _context.Responses.Where(x => x.PollId == pollId && x.ResponseId == responseId && x.QueryId == queryId).Select(x=>x.UserId);
            return _context.Users.Where(x=>userIds.Contains(x.UserId)).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UserExist(int id)
        {
            return _context.Users.Any(x => x.UserId == id);
        }
    }
}
