using ClinicAppointmentSystem.Models;
using ClinicAppointmentSystem.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentSystem.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;

        public DoctorService(IDoctorRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> AddDoctorAsync(Doctor doctor)
        {
            return await _repository.AddDoctorAsync(doctor);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var findDoc = await _repository.GetDoctorByIdAsync(id);
            if (findDoc == null)
            {
                throw new NotImplementedException();
            }
            await _repository.DeleteDoctorAsync(findDoc);
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _repository.GetAllDoctorsAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            var doctor = await _repository.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                throw new NotImplementedException();
            }

            return doctor;
        }

        public async Task<int> UpdateDoctorAsync(Doctor doctor)
        {
            var doctorExists = await _repository.GetDoctorByIdAsync(doctor.DoctorId);
            if (doctorExists == null)
            {
                throw new NotImplementedException();
            }
            return await _repository.UpdateDoctorAsync(doctor);
        }
    }
}
