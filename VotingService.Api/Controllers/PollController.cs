using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VotingService.Dto;
using VotingService.Models;
using VotingService.Service.Interfaces;

namespace VotingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PollController : Controller
    {
        private readonly IPollService _pollService;

        public PollController(IPollService pollService)
        {
            _pollService = pollService;
        }

        [HttpGet("GetPolls")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PollModel>))]
        public IActionResult GetPolls()
        {
            //var polls = _mapper.Map<List<PollGetDto>>(_pollRepository.GetPolls());
            var polls = _pollService.GetPolls();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(polls);
        }

        [HttpGet("GetPollId")]
        [ProducesResponseType(200, Type = typeof(PollModel))]
        public IActionResult GetQueryById(int pollId)
        {
            //var poll = _mapper.Map<PollGetDto>(_pollRepository.GetPollById(pollId));
            var poll = _pollService.GetPollById(pollId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(poll);
        }

        [HttpPost("CreatePoll")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePoll(PollPostDto pollcreate)
        {

            if (pollcreate == null)
            {
                return BadRequest(ModelState);
            }
            //var poll = _pollRepository.GetPolls().Where(c => c.PollName.ToLower() == pollcreate.PollName.ToLower()).FirstOrDefault();


            //if (poll != null)
            //{
            //    ModelState.AddModelError("", "Poll Already Exists");
            //    return StatusCode(422, ModelState);
            //}

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var PollMap = _mapper.Map<PollModel>(pollcreate);

            if (!_pollService.CreatePoll(pollcreate))
            {
                ModelState.AddModelError("", "Poll is not Created [CONTOLLER]");
                return StatusCode(500, ModelState);
            }
            return Ok("Poll Successfully Created");
        }
    }
}
