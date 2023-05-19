using AutoMapper;
using VotingService.Domain.Interfaces;
using VotingService.Dto;
using VotingService.Models;
using VotingService.Service.Interfaces;

namespace VotingService.Service.Repository
{
    public class ResponseService : IResponseService
    {
        private readonly IResponseRepository _responseRepository;
        private readonly IMapper _mapper;

        public ResponseService(IResponseRepository responseRepository, IMapper mapper)
        {
            _responseRepository = responseRepository;
            _mapper = mapper;
        }

        public bool CreateResponse(ResponsePostDto responsecreate)
        {
            var reponse = _responseRepository.GetResponses().Where(c =>
                    c.UserId == responsecreate.UserId &&
                    c.QueryId == responsecreate.QueryId &&
                    c.PollId == responsecreate.PollId &&
                    c.SolutionId == responsecreate.SolutionId).FirstOrDefault();

            if (reponse != null)
            {
                return false; // Query already exists
            }

            var RepsonseMap = _mapper.Map<ResponseModel>(responsecreate);

            return _responseRepository.CreateResponse(RepsonseMap);
        }

        public IEnumerable<SolutionModel> GetRankedSolution(int queryId, int pollId)
        {
            throw new NotImplementedException();
        }

        public List<string> GetRankedSolutionNames(int pollId, int queryId)
        {
            throw new NotImplementedException();
        }

        public ResponseGetDto GetResponseById(int reposneid)
        {
            return _mapper.Map<ResponseGetDto>(_responseRepository.GetResponseById(reposneid));
        }

        public ICollection<ResponseGetDto> GetResponses()
        {
            return _mapper.Map<List<ResponseGetDto>>(_responseRepository.GetResponses());
        }

        public Dictionary<int, List<int>> GetUsersBySolutionAndPoll(int queryId, int pollId)
        {
            throw new NotImplementedException();
        }

        public List<int> Get_USerIds_By_SolutionId(int pollId, int queryId, int solutionId)
        {
            throw new NotImplementedException();
        }
    }
}
