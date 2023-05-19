using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VotingService.Models
{
    public class ResponseModel
    {
        [Key]
        public int ResponseId { get; set; }

        public int PollId { get; set; }
        [ForeignKey("PollId")]
        public virtual PollModel Poll { get; set; }

        
        public int QueryId { get; set; }
        [ForeignKey("QueryId")]
        public virtual QueryModel Query { get; set; }

        public int SolutionId { get; set; }
        [ForeignKey("SolutionId")]
        public virtual SolutionModel Solution { get; set; }

        public int UserId{ get; set; }
        [ForeignKey("UserId")]
        public virtual UserModel User { get; set; }
    }
}
