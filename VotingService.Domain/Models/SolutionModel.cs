using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VotingService.Models
{
    public class SolutionModel
    {
        [Key]
        public int SolutionId { get; set; }

        public string SolutionName { get; set; }

        [Required]
        public int QueryId { get; set; }

        [ForeignKey("QueryId")]
        public virtual QueryModel Query { get; set; }

        //public virtual ICollection<ResponseModel> Responses { get; set; }

    }
}
