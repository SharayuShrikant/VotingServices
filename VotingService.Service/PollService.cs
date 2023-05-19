using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingService.Domain.Interfaces;
using VotingService.Dto;
using VotingService.Models;
using VotingService.Service.Interfaces;

namespace VotingService.Service.Repository
{
    public class PollService : IPollService
    {
        private readonly IPollRepository _pollRepository;
        private readonly IMapper _mapper;

        public PollService(IPollRepository pollRepository, IMapper mapper)
        {
            _pollRepository = pollRepository;
            _mapper = mapper;
        }
        public bool CreatePoll(PollPostDto pollcreate)
        {
            var poll = _pollRepository.GetPolls().Where(c => c.PollName.ToLower() == pollcreate.PollName.ToLower()).FirstOrDefault();

            if (pollcreate != null)
            {
                return false; // Query already exists
            }

            var PollMap = _mapper.Map<PollModel>(pollcreate);

            return _pollRepository.CreatePoll(PollMap);
        }

        public PollGetDto GetPollById(int pollId)
        {
            return _mapper.Map<PollGetDto>(_pollRepository.GetPollById(pollId));
        }

        public ICollection<PollGetDto> GetPolls()
        {
            return _mapper.Map<List<PollGetDto>>(_pollRepository.GetPolls());
        }
    }
}
