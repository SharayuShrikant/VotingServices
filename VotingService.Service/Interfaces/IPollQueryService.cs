using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingService.Dto;
using VotingService.Models;

namespace VotingService.Service.Interfaces
{
    public interface IPollQueryService
    {
        ICollection<PollQueryGetDto> GetPollQueries();

        PollQueryGetDto GetPollQueryById(int queryId);

        ICollection<PollQueryGetDto> GetPollQueriesByPollId(int pollid);

        bool CreatePollQuery(PollQueryPostDto pollquery);
    }
}
