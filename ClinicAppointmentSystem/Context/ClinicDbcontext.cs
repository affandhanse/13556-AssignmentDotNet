using ClinicAppointmentSystem.Models;
using ClinicAppointmentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Clinic_Appointment_System.Configurations;

namespace ClinicAppointmentSystem.Context
{
    public class ClinicDbcontext: IdentityDbContext<User>
    {
        public ClinicDbcontext(DbContextOptions<ClinicDbcontext>options):base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
            builder.Entity<Appointment>()
               .HasOne(a => a.User)
               .WithMany()
               .HasForeignKey(a => a.UserId)
               .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<User>()
            //   .HasOne(u => u.Doctor)
            //   .WithMany()
            //   .HasForeignKey(u => u.DoctorId)
            //   .OnDelete(DeleteBehavior.SetNull);
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }


    }
}
