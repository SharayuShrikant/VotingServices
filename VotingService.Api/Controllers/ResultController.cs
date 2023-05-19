using Microsoft.AspNetCore.Mvc;
using VotingService.Dto;
using VotingService.Service.Interfaces;

namespace VotingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : Controller
    {
        //private readonly IResponseRepository _responseRepository;
        //private readonly IUserRepository _userRepository;
        //private readonly IMapper _mapper;
        private readonly IResultService _resultService;

        public ResultController(IResultService resultService)
        {
            _resultService = resultService; 

        }

        [HttpGet("GetUsersIdBySolutionId")]
        [ProducesResponseType(200, Type = typeof(List<int>))]
        public IActionResult GetUsersIdBySolutionId(int queryId, int pollId,int solutionId)
        {
            //var usersIdbysolution = _responseRepository.Get_USerIds_By_SolutionId(queryId, pollId, solutionId);
            var usersIdbysolution = _resultService.Get_USerIds_By_SolutionId(queryId, pollId, solutionId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(usersIdbysolution);
        }

        [HttpGet("GetRankedSolutionModel")]
        [ProducesResponseType(200, Type = typeof(List<SolutionGetDto>))]
        public IActionResult GetRankedSolution(int queryId, int pollId)
        {
            //var rankedsolutions = _mapper.Map < List < SolutionGetDto >> (_responseRepository.GetRankedSolution(queryId, pollId));
            var rankedsolutions = _resultService.GetRankedSolution(queryId, pollId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(rankedsolutions);
        }

        [HttpGet("GetRankedSolutionName")]
        [ProducesResponseType(200, Type = typeof(List<string>))]
        public IActionResult GetRankedSolutionName(int queryId, int pollId)
        {
            //var rankedsolutionnames = _responseRepository.GetRankedSolutionNames(queryId, pollId);
            var rankedsolutionnames = _resultService.GetRankedSolutionNames(pollId, queryId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(rankedsolutionnames);
        }

        [HttpGet("GetUsersModelBySolutionId")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserPublicGetDto>))]
        public IActionResult GetUsersModelBySolutionId(int queryId, int pollId, int solutionId)
        {
            //var usersIds = _responseRepository.Get_USerIds_By_SolutionId(queryId, pollId, solutionId);
            var users = _resultService.GetUsersModelBySolutionId(queryId, pollId, solutionId);  

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);
        }
    }
}
