using VotingService.Models;

namespace VotingService.Domain.Interfaces
{
    public interface IUserRepository
    {
        ICollection<UserModel> GetUser();

        UserModel GetUserById(int id);

        UserModel GetUserByUsername(string username);

        public ICollection<UserModel> GetUsersByResponse(int responseId, int pollId, int queryId);

        bool CreateUser(UserModel user);

        public bool UserExist(int id);

        bool Save();
    }
}
