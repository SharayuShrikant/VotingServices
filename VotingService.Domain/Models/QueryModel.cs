using System.ComponentModel.DataAnnotations;

namespace VotingService.Models
{
    public class QueryModel
    {
        [Key]
        public int QueryId { get; set; }

        [Required]
        public string Query { get; set; }

        public virtual ICollection<SolutionModel> Solutions { get; set; }
        
        public virtual ICollection<PollQueryModel> PollQueries { get; set; }
        
        //public virtual ICollection<ResponseModel> Responses { get; set; }

    }
}
