
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VotingService.Models
{
    public class PollQueryModel
    {
        [Key]
        public int PollSessionId { get; set; }

        [Required]
        public int PollId { get; set; }
        [ForeignKey("PollId")]
        public virtual PollModel Poll { get; set; }

        [Required]
        public int QueryId { get; set; }
        [ForeignKey("QueryId")]
        public virtual QueryModel Query { get; set; }
    }
}
