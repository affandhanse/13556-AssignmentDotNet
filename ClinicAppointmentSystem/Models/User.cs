using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ClinicAppointmentSystem.Models
{

    public class User : IdentityUser
    {


        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public int? DoctorId { get; set; } // Nullable to allow for patients and admins
        public Doctor Doctor { get; set; }

        //public ICollection<Appointment> Appointments { get; set; }

    }
}