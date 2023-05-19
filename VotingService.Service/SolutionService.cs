using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using VotingService.Dto;
using VotingService.Service.Interfaces;
using VotingService.Domain.Interfaces;
using VotingService.Models;

namespace VotingService.Service.Repository
{
    public class SolutionService : ISolutionService
    {
        private readonly ISolutionRepository _solutionRepository;
        private readonly IMapper _mapper;

        public SolutionService(ISolutionRepository solutionRepository, IMapper mapper)
        {
            _solutionRepository = solutionRepository;
            _mapper = mapper;
        }
        public bool CreateSolution(SolutionPostDto solutioncreate)
        {
            var solution = _solutionRepository.GetSolutions().Where(c => c.SolutionName.ToLower() == solutioncreate.SolutionName.ToLower()).FirstOrDefault();

            if (solution != null)
            {
                return false; // Query already exists
            }

            var SolutionMap = _mapper.Map<SolutionModel>(solutioncreate);

            return _solutionRepository.CreateSolution(SolutionMap);
        }

        public SolutionGetDto GetSolutionById(int solutionid)
        {
           return _mapper.Map<SolutionGetDto>(_solutionRepository.GetSolutionById(solutionid));
        }

        public ICollection<SolutionGetDto> GetSolutions()
        {
            return _mapper.Map<List<SolutionGetDto>>(_solutionRepository.GetSolutions());
        }

        public ICollection<SolutionGetDto> GetSolutionsByQueryId(int queryId)
        {
            return _mapper.Map<List<SolutionGetDto>>(_solutionRepository.GetSolutionsByQueryId(queryId));
        }
    }
}
