using Microsoft.AspNetCore.Mvc;
using VotingService.Dto;
using VotingService.Models;
using VotingService.Service.Interfaces;

namespace VotingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollQueryController : Controller
    {
        private readonly IPollQueryService _pollQueryService;

        public PollQueryController(IPollQueryService pollQueryService)
        {
            _pollQueryService = pollQueryService;
        }

        [HttpGet("GetPollQuery")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PollQueryModel>))]
        public IActionResult GetPollQuery()
        {
            //var pollqueries = _mapper.Map<List<PollQueryGetDto>>(_pollQueryRepository.GetPollQueries());
            var pollqueries = _pollQueryService.GetPollQueries();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pollqueries);
        }

        [HttpGet("GetPollQueryByPollId")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PollQueryModel>))]
        public IActionResult GetPollQueryByPollId(int pollId)
        {
            //var pollqueries = _mapper.Map<List<PollQueryGetDto>>(_pollQueryRepository.GetPollQueriesByPollId(pollId));
            var pollqueries = _pollQueryService.GetPollQueriesByPollId(pollId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pollqueries);
        }

        [HttpGet("GetPollQueryById")]
        [ProducesResponseType(200, Type = typeof(PollQueryModel))]
        public IActionResult GetPollQueryById(int pollqueryId)
        {
            //var pollquery = _mapper.Map<PollQueryGetDto>(_pollQueryRepository.GetPollQueryById(pollqueryId));
            var pollquery = _pollQueryService.GetPollQueryById(pollqueryId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pollquery);
        }


        [HttpPost("CreatePollQuery")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateQuery(PollQueryPostDto pollquerycreate)
        {

            if (pollquerycreate == null)
            {
                return BadRequest(ModelState);
            }
            //var pollquery = _pollQueryRepository.GetPollQueries().Where(c => c.PollId == pollquerycreate.PollId && c.QueryId == pollquerycreate.QueryId).FirstOrDefault();


            //if (pollquery != null)
            //{
            //    ModelState.AddModelError("", "PollQuery Already Exists");
            //    return StatusCode(422, ModelState);
            //}

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var PollQueryMap = _mapper.Map<PollQueryModel>(pollquerycreate);

            if (!_pollQueryService.CreatePollQuery(pollquerycreate))
            {
                ModelState.AddModelError("", "PollQuery is not Created [CONTOLLER]");
                return StatusCode(500, ModelState);
            }
            return Ok("PollQuery Successfully Created");
        }
    }
}
