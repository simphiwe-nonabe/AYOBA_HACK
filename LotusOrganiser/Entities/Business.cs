using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LotusOrganiser.Entities
{
    public sealed class Business
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BusinessId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string msisdn { get; set; }


        [Required]
        [MaxLength(50)]
        public string VATNumber { get; set; }

   
        public string url { get; set; }

        [DefaultValue(typeof(DateTime), "")]
        public DateTime requestTime { get; set; } = DateTime.Now;

    }
}
