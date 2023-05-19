using System.ComponentModel.DataAnnotations;

namespace VotingService.Models
{
    public class PollModel
    {
        [Key]
        public int PollId { get; set; }

        [Required]
        public string PollName { get; set; }

        [Required]
        public DateTime startDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual ICollection<PollQueryModel> PollQueries { get; set; }

        //public virtual ICollection<ResponseModel> Responses { get; set; }


    }
}
