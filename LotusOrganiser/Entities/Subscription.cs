﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LotusOrganiser.Entities
{
    public sealed class Subscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SubscriptionId { get; set; }

        [Required]
        public long BusinessId { get; set; }

        [Required]
        public long UserId { get; set; }

        [ForeignKey(nameof(BusinessId))]
        public Business Business { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}