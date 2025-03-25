using ClinicAppointmentSystem.Models;

namespace ClinicAppointmentSystem.Repository
{
    public interface IDoctorRepository
    {
        Task<int> AddDoctorAsync(Doctor doctor);
        Task DeleteDoctorAsync(Doctor findDoc);
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<Doctor> GetDoctorByIdAsync(int id);
        Task<int> UpdateDoctorAsync(Doctor doctor);
    }
}
