using ClinicAppointmentSystem.Models;

namespace ClinicAppointmentSystem.Service
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(int userId);
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task<IEnumerable<Appointment>> GetAllAppointmentByIdAsync(string userId);
        Task<int> AddAppointmentAsync(Appointment appointment);
        Task<int> UpdateAppointmentStatusAsync(int id, string status);
        Task<int> DeleteAppointmentAsync(int id);
    }
}
