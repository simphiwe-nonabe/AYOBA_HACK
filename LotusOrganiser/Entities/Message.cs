using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LotusOrganiser.Entities
{
    public sealed class Message
    {
        [Key]
        public string id { get; set; }

        public string type { get; set; }

        public string text { get; set; }

        public string msisdn { get; set; }

        public string url { get; set; }

        public string value { get; set; }

        public int width { get; set; }

        public int height { get; set; }

        public string caption { get; set; }

        [DefaultValue(typeof(DateTime), "")]
        public DateTime requestTime { get; set; } = DateTime.Now;

        public long BusinessId { get; set; }

        public long UserId { get; set; }

        [ForeignKey(nameof(BusinessId))]
        public Business Business { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

    }
}
