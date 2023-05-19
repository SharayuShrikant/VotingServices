using AutoMapper;
using VotingService.Dto;
using VotingService.Service.Interfaces;
using VotingService.Domain.Interfaces;
using VotingService.Models;

namespace VotingService.Service.Repository
{
    public class ResultService : IResultService
    {
        private readonly IResponseRepository _responseRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public ResultService(IResponseRepository responseRepository, IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _responseRepository = responseRepository;   
            _userRepository = userRepository;   
        }
        public IEnumerable<SolutionGetDto> GetRankedSolution(int queryId, int pollId)
        {
          return  _mapper.Map<List<SolutionGetDto>>(_responseRepository.GetRankedSolution(queryId, pollId));
        }

        public IEnumerable<UserPublicGetDto> GetUsersModelBySolutionId(int queryId, int pollId, int solutionId)
        {
            var usersIds = _responseRepository.Get_USerIds_By_SolutionId(queryId, pollId, solutionId);
            var users = _mapper.Map<List<UserPublicGetDto>>(_userRepository.GetUser().Where(x => usersIds.Contains(x.UserId)).ToList());
            return users;
        }

        public List<int> Get_USerIds_By_SolutionId(int pollId, int queryId, int solutionId)
        {
            return _responseRepository.Get_USerIds_By_SolutionId(queryId, pollId, solutionId);
        }

        public List<string> GetRankedSolutionNames(int pollId, int queryId)
        {
            return _responseRepository.GetRankedSolutionNames(queryId, pollId);
        }
    }
}
