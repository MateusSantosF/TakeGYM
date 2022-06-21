

using Microsoft.EntityFrameworkCore;

using TakeGYM.Models.Exercise;
using TakeGYM.Models.ExerciseTrainingSheet;
using TakeGYM.Models.PersonalAlert;
using TakeGYM.Models.Student;
using TakeGYM.Models.Teacher;
using TakeGYM.Models.TrainingSheet;

namespace TakeGYM.Services.AppDbContext
{
    public class TakeGYMContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<TrainingSheet> TrainingSheets { get; set; }

        public DbSet<PersonalAlert> PersonalAlerts { get; set; }


        public TakeGYMContext(DbContextOptions<TakeGYMContext> options): base(options)
        {
            
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExerciseTraningsheet>()
                .HasKey(bc => new { bc.ExerciseID, bc.TrainingsheetID });

            modelBuilder.Entity<ExerciseTraningsheet>()
                .HasOne(bc => bc.Trainingsheet)
                .WithMany(b => b.Exercises)
                .HasForeignKey(bc => bc.ExerciseID);


            modelBuilder.Entity<Teacher>()
                    .HasMany(s => s.Students)
                    .WithOne(s => s.Teacher).OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Teacher>()
                .HasMany<PersonalAlert>( t => t.Alerts)
                .WithOne( a => a.Personal)
                .OnDelete(DeleteBehavior.NoAction);


        }




    }
}
