using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoinGardenWorldMobileApp.DotNetApi.Entities
{
    public class AccountDTO : BaseDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; } = Guid.NewGuid();


        //The placeholders I am aware of are:
        // 
        // {0} = Property Name
        // {1} = Max Length
        // {2} = Min Length
        [StringLength(150, ErrorMessage = "{0} can have a max of {1} characters")]
        public string? Email { get; set; }
        [StringLength(150, ErrorMessage = "{0} can have a max of {1} characters")]
        public string? Username { get; set; }

        [StringLength(150, ErrorMessage = "{0} can have a max of {1} characters")]
        public string? DisplayName { get; set; }
        [StringLength(500, ErrorMessage = "{0} can have a max of {1} characters")]
        public string? ProfileIntroduction { get; set; }

        public byte[]? ProfilePicure { get; set; }


        [InverseProperty("Account")]
        public List<GardenDTO> Gardens { get; } = new();



    }
}
