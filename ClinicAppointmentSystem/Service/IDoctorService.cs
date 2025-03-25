using ClinicAppointmentSystem.Models;

namespace ClinicAppointmentSystem.Service
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<int> AddDoctorAsync(Doctor doctor);
        Task<int> UpdateDoctorAsync(Doctor doctor);
        Task DeleteDoctorAsync(int id);
    }
}
