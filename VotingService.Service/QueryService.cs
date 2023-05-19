using AutoMapper;
using VotingService.Dto;
using VotingService.Service.Interfaces;
using VotingService.Domain.Interfaces;
using VotingService.Models;

namespace VotingService.Service.Repository
{
    public class QueryService : IQueryService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly IMapper _mapper;

        public QueryService(IQueryRepository queryRepository , IMapper mapper)
        {
            _queryRepository = queryRepository;
            _mapper = mapper;
        }

        public bool CreateQuery(QueryPostDto querycreate)
        {
            var query = _queryRepository.GetQueries().FirstOrDefault(c => c.Query.ToLower() == querycreate.Query.ToLower());

            if (query != null)
            {
                return false; // Query already exists
            }

            var QueryMap = _mapper.Map<QueryModel>(querycreate);

            return _queryRepository.CreateQuery(QueryMap);
        }

        public ICollection<QueryGetDto> GetQueries()
        {
            return _mapper.Map<List<QueryGetDto>>(_queryRepository.GetQueries());
        }

        public ICollection<QueryGetDto> GetQueriesByPollId(int pollId)
        {
            return _mapper.Map<List<QueryGetDto>>(_queryRepository.GetQueriesByPollId(pollId));
        }

        public QueryGetDto GetQueryById(int queryid)
        {
            return _mapper.Map<QueryGetDto>(_queryRepository.GetQueryById(queryid));
        }
    }
}
