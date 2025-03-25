using Clinic_Appointment_System.Exceptions;
using ClinicAppointmentSystem.Models;
using ClinicAppointmentSystem.Repository;

namespace ClinicAppointmentSystem.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService (IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<int> AddAppointmentAsync(Appointment appointment)
        {
            return await _appointmentRepository.AddAppointmentAsync(appointment); 
        }

        public async Task<int> DeleteAppointmentAsync(int id)
        {
            var appointment = await _appointmentRepository.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                throw new ArgumentNullException(nameof(appointment));
            }
            return await _appointmentRepository.DeleteAppointmentAsync(appointment);
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(int userId)
        {
            return await _appointmentRepository.GetAllAppointmentsAsync(userId);
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorIdAsync(int doctorId)
        {
            return await _appointmentRepository.GetAppointmentsByDoctorIdAsync(doctorId);
        }

        //public async Task<Appointment> GetAppointmentByIdAsync(int id)
        //{
        //    var appointment = await _appointmentRepository.GetAppointmentByIdAsync(id);
        //    if (appointment == null)
        //    {
        //        throw new ArgumentNullException(nameof(appointment));
        //    }
        //    return await _appointmentRepository.GetAppointmentByIdAsync(id);
        //}

       public Task<int> UpdateAppointmentStatusAsync(int id, string status)
        {
            return _appointmentRepository.UpdateAppointmentStatusAsync(id, status);
        }
        public Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            var appointment = _appointmentRepository.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                throw new AppointmentNotFoundException($"Appointment not exist with id:{id}");
            }
            return appointment;
        }


        public Task<IEnumerable<Appointment>> GetAllAppointmentByIdAsync(string userId)
        {
            return _appointmentRepository.GetAllAppointmentByIdAsync(userId);
        }
    }
}
