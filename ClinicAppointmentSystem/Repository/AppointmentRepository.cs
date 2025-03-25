using ClinicAppointmentSystem.Context;
using ClinicAppointmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentSystem.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ClinicDbcontext _dbcontext;

        public AppointmentRepository (ClinicDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<int> AddAppointmentAsync(Appointment appointment)
        {
            await _dbcontext.Appointments.AddAsync(appointment);
            return await _dbcontext.SaveChangesAsync();
        }

        public async Task<int> DeleteAppointmentAsync(Appointment appointment)
        {
            _dbcontext.Appointments.Remove(appointment);
            return await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(int userId)
        {
            return await _dbcontext.Appointments.Include(p => p.Doctor).Include(p => p.User).ToListAsync();

            //return await _dbcontext.Appointments.Where(p => p.PatientId == userId).Include(p => p.Doctor).ToListAsync();
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            return await _dbcontext.Appointments
                .Include(p => p.Doctor)
                .FirstOrDefaultAsync(p => p.DoctorId == id);
            //var appointmant = await _dbcontext.Appointments.FindAsync(id);
            //if (appointmant != null)
            //{
            //    return appointmant;
            //}
            //throw new NotImplementedException();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorIdAsync(int doctorId)
        {
            return await _dbcontext.Appointments
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<int> UpdateAppointmentStatusAsync(int id, string status)
        {
            
                if (Enum.TryParse(status, out Status parStatus))
                {
                    var appointment = await _dbcontext.Appointments.FindAsync(id);
                    if(appointment != null)
                    {
                    appointment.Status = parStatus;
                    _dbcontext.Appointments.Update(appointment);
                    return await _dbcontext.SaveChangesAsync();

                    }
                   
                }
                return 0;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentByIdAsync(string userId)
        {
            return await _dbcontext.Appointments
                .Include(p => p.Doctor)
                .Include(p => p.User)
                .Where(a => a.UserId ==userId)
                .ToListAsync();
        }
    }
}
