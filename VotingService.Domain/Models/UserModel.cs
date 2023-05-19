using System.ComponentModel.DataAnnotations;

namespace VotingService.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; }

        //public virtual ICollection<ResponseModel> Responses { get; set; }

    }
}
