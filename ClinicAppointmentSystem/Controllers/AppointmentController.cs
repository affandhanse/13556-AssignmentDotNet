using System.Security.Claims;
using ClinicAppointmentSystem.Models;
using ClinicAppointmentSystem.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClinicAppointmentSystem.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IDoctorService _doctorService;
        public AppointmentController (IAppointmentService appointmentService, IDoctorService doctorService )
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllByIdAppointments()
        {

            var UserId = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(UserId))
            {
                return RedirectToAction("Login", "Account");
            }

            var appointments = await _appointmentService.GetAllAppointmentByIdAsync(UserId);
            return View(appointments);

        }
        //public async Task<IActionResult> PatientAppointments()
        //{
        //    //int UserId = int.Parse(User.FindFirst("UserId").Value);
        //    //var appointments = await _appointmentService.GetAllAppointmentsAsync(UserId);
        //    return View(await _appointmentService.GetAllAppointmentsAsync());
        //}
        //public async Task<IActionResult> DoctorAppointments()
        //{
        //    int doctorId = int.Parse(User.FindFirst("UserId").Value);
        //    var appointments = await _appointmentService.GetAllAppointmentsAsync(doctorId);
        //    return View(appointments);
        //}
        public async Task<IActionResult> AllAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync(0);
            return View(appointments);
        }
        [HttpGet]
        public async Task<IActionResult> AddAppointment()
        {
            ViewData["DoctorId"] = new SelectList(await _doctorService.GetAllDoctorsAsync(), "DoctorId", "Name");
            //ViewData["Status"] = Enum.GetValues(typeof(Status)).Cast<Status>().Select(s=> new SelectListItem{Text=s.ToString(),Value=s.ToString() });
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> AddAppointment(Appointment appointment)
        {
            var UserId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(UserId))
            {
                return RedirectToAction("Login", "Account");
            }
            appointment.UserId = UserId;
            ModelState.Remove("Doctor");
            ModelState.Remove("User");
            ModelState.Remove("UserId");
            
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                int affectedRows = await _appointmentService.AddAppointmentAsync(appointment);
                if (affectedRows > 0)
                {
                    TempData["message"] = "Appointment Added Succesfuly";
                    return RedirectToAction("GetAllByIdAppointments");
                }
                else
                {
                    TempData["message"] = "Appointment Addition Failed ";
                    return RedirectToAction("");

                }
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAppointment(int id)
        {

            return View(await _appointmentService.GetAppointmentByIdAsync(id));
        }



        //[HttpGet]
        //public async Task<IActionResult> UpdateAppointmentStatus(int id)
        //{
        //    var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
        //    ViewData["DoctorId"] = new SelectList(await _doctorService.GetAllDoctorsAsync(), "DoctorId", "Name");
        //    if (appointment == null)
        //    {
        //        TempData["Error"] = "Appointment not found.";
        //        return RedirectToAction("AllAppointments");
        //    }

        //    return View(appointment);
        //}
        //public async Task<IActionResult> UpdateAppointmentStatus(int id, Appointment appointment)
        //{
        //    try
        //    {
        //        await _appointmentService.UpdateAppointmentStatusAsync(id, appointment);
        //        TempData["Success"] = "Appointment status updated successfully.";
        //    }
        //    catch (KeyNotFoundException ex)
        //    {
        //        TempData["Error"] = ex.Message;
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        TempData["Error"] = ex.Message;
        //    }
        //    return RedirectToAction("AllAppointments");
        //}
        [HttpGet]
        public async Task<IActionResult> EditAppointmentStatus(int id)
        {
            return View(await _appointmentService.GetAppointmentByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> EditAppointmentStatus(int id, string status)
        {
            await _appointmentService.UpdateAppointmentStatusAsync(id, status);
            return RedirectToAction("GetAllByIdAppointments");
        }
        [HttpGet]
        [HttpDelete]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _appointmentService.DeleteAppointmentAsync(id);
            return RedirectToAction("GetAllByIdAppointments");
        }


    }
}
 