using Microsoft.AspNetCore.Mvc;
using VotingService.Dto;
using VotingService.Models;
using VotingService.Service.Interfaces;

namespace VotingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : Controller
    {
        private readonly IResponseService _responseService;
        //private readonly IMapper _mapper;

        public ResponseController(IResponseService responseService)
        {
            _responseService = responseService;
        }

        [HttpGet("GetResponses")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ResponseModel>))]
        public IActionResult GetQueries()
        {
            //var responses = _mapper.Map<List<ResponseGetDto>>(_responseRepository.GetResponses());
            var responses = _responseService.GetResponses();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            return Ok(responses);
        }

        [HttpGet("GetResponsesById")]
        [ProducesResponseType(200, Type = typeof(ResponseModel))]
        public IActionResult GetQueryById(int responseid)
        {
            //var response = _mapper.Map<ResponseGetDto>(_responseRepository.GetResponseById(responseid));
            var response = _responseService.GetResponseById(responseid);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(response);
        }

        [HttpPost("CreateResponse")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateQuery(ResponsePostDto responsecreate)
        {

            if (responsecreate == null)
            {
                return BadRequest(ModelState);
            }
            //var reponse = _responseRepository.GetResponses().Where(c =>
            //        c.UserId == responsecreate.UserId &&
            //        c.QueryId == responsecreate.QueryId &&
            //        c.PollId == responsecreate.PollId &&
            //        c.SolutionId == responsecreate.SolutionId).FirstOrDefault();

            //if (reponse != null)
            //{
            //    ModelState.AddModelError("", "Response Already Exists");
            //    return StatusCode(422, ModelState);
            //}

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var RepsonseMap = _mapper.Map<ResponseModel>(responsecreate);

            if (!_responseService.CreateResponse(responsecreate))
            {
                ModelState.AddModelError("", "Response is not Created [CONTOLLER]");
                return StatusCode(500, ModelState);
            }
            return Ok("Response Successfully Created");
        }


    }


}
