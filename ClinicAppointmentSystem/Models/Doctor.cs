namespace ClinicAppointmentSystem.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }

        public List<Appointment> Appointments { get; set; }

        //public string UserId { get; set; }
    }
}
