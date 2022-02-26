using System;
using System.ComponentModel.DataAnnotations;

namespace DylanThierbachCsharpExam.Models
{
    public class Participant
    {
        [Key]
        public int ParticipantId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public User User { get; set; }

        public int ActivId { get; set; }
        public Activ Activ { get; set; }
    }
}