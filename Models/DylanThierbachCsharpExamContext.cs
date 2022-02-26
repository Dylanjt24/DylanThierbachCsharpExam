using Microsoft.EntityFrameworkCore;
 
namespace DylanThierbachCsharpExam.Models
{
    public class DylanThierbachCsharpExamContext : DbContext
    {
        public DylanThierbachCsharpExamContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Activ> Activs { get; set; }
        public DbSet<Participant> Participants { get; set; }
    }
}
