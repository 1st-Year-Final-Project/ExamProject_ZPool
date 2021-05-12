using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using UserManagementTestApp.Models;

namespace ZPool.Models
{
    public class Message
    {
        public int Id { get; set; }
        public bool IsRead { get; set; }
        [Required]
        [StringLength(240)]
        public string MessageBody { get; set; }
        public DateTime SendingDate { get; set; }

        [Required]
        public int SenderId { get; set; }
        [ForeignKey(nameof(SenderId))]
        public AppUser Sender { get; set; }

        [Required]
        public int ReceiverId { get; set; }
        [ForeignKey(nameof(ReceiverId))]
        public AppUser Receiver { get; set; }
    }
}
