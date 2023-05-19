using AutoMapper;
using VotingService.Dto;
using VotingService.Service.Interfaces;
using VotingService.Domain.Interfaces;
using VotingService.Models;

namespace VotingService.Service.Repository
{
    public class PollQueryService : IPollQueryService
    {
        private readonly IPollQueryRepository _pollQueryRepository;
        private readonly IMapper _mapper;

        public PollQueryService(IPollQueryRepository pollQueryRepository, IMapper mapper)
        {
            _pollQueryRepository = pollQueryRepository;
            _mapper = mapper;
        }
        public bool CreatePollQuery(PollQueryPostDto pollquerycreate)
        {
            var pollquery = _pollQueryRepository.GetPollQueries().Where(c => c.PollId == pollquerycreate.PollId && c.QueryId == pollquerycreate.QueryId).FirstOrDefault();

            if (pollquery != null)
            {
                return false; // Query already exists
            }

            var PollQueryMap = _mapper.Map<PollQueryModel>(pollquerycreate);

            return _pollQueryRepository.CreatePollQuery(PollQueryMap);
        }

        public ICollection<PollQueryGetDto> GetPollQueries()
        {
            return _mapper.Map<List<PollQueryGetDto>>(_pollQueryRepository.GetPollQueries());
        }

        public ICollection<PollQueryGetDto> GetPollQueriesByPollId(int pollId)
        {
            return _mapper.Map<List<PollQueryGetDto>>(_pollQueryRepository.GetPollQueriesByPollId(pollId));
        }

        public PollQueryGetDto GetPollQueryById(int pollqueryId)
        {
            return _mapper.Map<PollQueryGetDto>(_pollQueryRepository.GetPollQueryById(pollqueryId));
        }
    }
}
