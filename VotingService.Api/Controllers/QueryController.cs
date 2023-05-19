using VotingService.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using VotingService.Models;
using VotingService.Dto;

namespace VotingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : Controller
    {
        private readonly IQueryService _queryservice;
        //private readonly IMapper _mapper;

        public QueryController(IQueryService queryservice)
        {
            _queryservice = queryservice;
        }

        [HttpGet("GetQueries")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<QueryModel>))]
        public IActionResult GetQueries()
        {
            //var queries = _mapper.Map<List<QueryGetDto>>(_queryRepository.GetQueries());
            var queries = _queryservice.GetQueries();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(queries);
        }


        [HttpGet("GetQueryById")]
        [ProducesResponseType(200, Type = typeof(QueryModel))]
        public IActionResult GetQueryById(int queryid)
        {
            //var query = _mapper.Map<QueryGetDto>(_queryRepository.GetQueryById(queryid));
            var query = _queryservice.GetQueryById(queryid);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(query);
        }

        [HttpPost("CreateQuery")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateQuery(QueryPostDto querycreate)
        {

            if (querycreate == null)
            {
                return BadRequest(ModelState);
            }
            //var query = _queryRepository.GetQueries().Where(c => c.Query.ToLower() == querycreate.Query.ToLower()).FirstOrDefault();


            //if (query != null)
            //{
            //    ModelState.AddModelError("", "Query Already Exists");
            //    return StatusCode(422, ModelState);
            //}

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var QueryMap = _mapper.Map<QueryModel>(querycreate);

            if (!_queryservice.CreateQuery(querycreate))
            {
                ModelState.AddModelError("", "Query is not Created [CONTOLLER]");
                return StatusCode(500, ModelState);
            }
            return Ok("Query Successfully Created");
        }

        [HttpGet("GetQueriesByPollId")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<QueryModel>))]
        public IActionResult GetQueriesByPollId(int pollId)
        {
            //var queries = _mapper.Map<List<QueryGetDto>>(_queryRepository.GetQueriesByPollId(pollId));
            var queries = _queryservice.GetQueriesByPollId(pollId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(queries);
        }
    }
}
