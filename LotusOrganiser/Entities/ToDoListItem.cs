using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LotusOrganiser.Entities
{
    public sealed class ToDoListItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ItemId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public bool Completed { get; set; }

        public long BusinessId { get; set; }

        public long UserId { get; set; }

        [ForeignKey(nameof(BusinessId))]
        public Business Business { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

    }
}
