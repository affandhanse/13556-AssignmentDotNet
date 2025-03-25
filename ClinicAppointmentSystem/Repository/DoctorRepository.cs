using ClinicAppointmentSystem.Context;
using ClinicAppointmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicAppointmentSystem.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ClinicDbcontext _context;

        public DoctorRepository (ClinicDbcontext context)
        {
            _context = context;
        }
        public async Task<int> AddDoctorAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            return await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(Doctor findDoc)
        {
            _context.Doctors.Remove(findDoc);
             await _context.SaveChangesAsync();
            //var findDoc = await _context.Doctors.FindAsync(id);
            //if (findDoc != null)
            //{
            //    _context.Doctors.Remove(findDoc);
            //    await _context.SaveChangesAsync();
            //}
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors.Include(p=>p.Appointments).ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _context.Doctors.Include(p => p.Appointments).FirstOrDefaultAsync(p => p.DoctorId == id);
        }

        public async Task<int> UpdateDoctorAsync(Doctor doctor)
        {
            var Doc = await _context.Doctors.FindAsync(doctor.DoctorId);

            Doc.Name = doctor.Name;
            Doc.Specialty = doctor.Specialty;
            _context.Doctors.Update(Doc);
            return await _context.SaveChangesAsync();
        }
    }
}
