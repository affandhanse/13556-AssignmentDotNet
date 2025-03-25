using System.ComponentModel.DataAnnotations.Schema;
using ClinicAppointmentSystem.Models;
using MessagePack;

namespace ClinicAppointmentSystem.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Status Status { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

    }
}
