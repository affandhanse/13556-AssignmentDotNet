using ClinicAppointmentSystem.Models;

namespace ClinicAppointmentSystem.Repository
{
    public interface IAppointmentRepository
    {
        Task<int> AddAppointmentAsync(Appointment appointment);
        Task<int> DeleteAppointmentAsync(Appointment appointment);
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(int userId);
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task<IEnumerable<Appointment>> GetAllAppointmentByIdAsync(string userId);
        Task<int> UpdateAppointmentStatusAsync(int id, string status);
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctorIdAsync(int doctorId);
    }
}