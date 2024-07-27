using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LotusOrganiser_API.Models.Business
{
    public class BusinessViewModel
    {
        private BusinessViewModel()
        {
            Name = default!;
        }

        [JsonConstructor]
        public BusinessViewModel(string name)
        {
            Name = name;
        } 

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
