using Microsoft.AspNetCore.Mvc;
using VotingService.Dto;
using VotingService.Models;
using VotingService.Service.Interfaces;


namespace VotingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionController : Controller
    {
        private readonly ISolutionService _solutionService;

        public SolutionController(ISolutionService solutionService)
        {
            _solutionService = solutionService;
        }

        [HttpGet("GetSolution")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SolutionModel>))]
        public IActionResult GetSolution()
        {
            //var solutions = _mapper.Map<List<SolutionGetDto>>(_solutionRepository.GetSolutions());
            var solutions = _solutionService.GetSolutions();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(solutions);
        }


        [HttpGet("GetSolutionById")]
        [ProducesResponseType(200, Type = typeof(SolutionModel))]
        public IActionResult GetSolutionById(int solutionid)
        {
            //var solution = _mapper.Map<SolutionGetDto>(_solutionRepository.GetSolutionById(solutionid));
            var solution = _solutionService.GetSolutionById(solutionid);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(solution);
        }

        [HttpGet("GetSolutionsByQueryId")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SolutionModel>))]
        public IActionResult GetSolutionsByQueryId(int queryId)
        {
            //var solutions = _mapper.Map<List<SolutionGetDto>>(_solutionRepository.GetSolutionsByQueryId(queryId));
            var solutions = _solutionService.GetSolutionsByQueryId(queryId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(solutions);
        }

        [HttpPost("CreateSolution")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateQuery(SolutionPostDto solutioncreate)
        {

            if (solutioncreate == null)
            {
                return BadRequest(ModelState);
            }
            //var solution = _solutionRepository.GetSolutions().Where(c => c.SolutionName.ToLower() == solutioncreate.SolutionName.ToLower()).FirstOrDefault();


            //if (solution != null)
            //{
            //    ModelState.AddModelError("", "Solution Already Exists");
            //    return StatusCode(422, ModelState);
            //}

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

            if (!_solutionService.CreateSolution(solutioncreate))
            {
                ModelState.AddModelError("", "solution is not Created [CONTOLLER]");
                return StatusCode(500, ModelState);
            }
            return Ok("Solution Successfully Created");
        }

    }
}
