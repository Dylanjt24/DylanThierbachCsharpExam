using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DylanThierbachCsharpExam.Models
{
    public class Activ
    {
        [Key]
        public int ActivId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [FutureDate]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        [Required]
        public int Duration { get; set; }
        [Required]
        public string DurationType { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        public User Creator { get; set; }
        public List<Participant> ActivParticipants { get; set; }
    }
}