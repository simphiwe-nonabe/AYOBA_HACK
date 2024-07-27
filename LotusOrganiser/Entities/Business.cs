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
    }
}
