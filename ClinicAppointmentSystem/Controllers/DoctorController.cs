
using ClinicAppointmentSystem.Models;
using ClinicAppointmentSystem.Service;
using ClinicAppointmentSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace ClinicAppointmentSystem.Controllers
{
    [Authorize(Roles = "Admin")]

    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        readonly UserManager<User> _userManager;
        readonly SignInManager<User> _signInManager;

        public DoctorController(IDoctorService doctorService, UserManager<User> manager, SignInManager<User> signInManager)
        {
            _doctorService = doctorService;
            _userManager = manager;
            _signInManager = signInManager;
        }

        
        public async Task<IActionResult> GetAllDoctor()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return View(doctors);
        }

        
        [HttpGet] 
        public IActionResult AddDoctor()
        {
            return View();
        }

        [HttpPost] 
        public async Task<IActionResult> AddDoctor(Register user, string specialty)
        {
            ModelState.Remove("Appointments");
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            else
            {
                var doctor = new Doctor
                {
                    Name = $"{user.FirstName} {user.LastName}", 
                    Specialty = specialty 
                };
                int result = await _doctorService.AddDoctorAsync(doctor);
                if (result > 0)
                {
                    var createdUser = new User { UserName = user.Email, Email = user.Email, FirstName = user.FirstName, LastName = user.LastName };
                    var NewDoctorUser = await _userManager.CreateAsync(createdUser, user.Password);
                    if (NewDoctorUser.Succeeded)
                    {

                        await _userManager.AddToRoleAsync(createdUser, Role.Doctor);
                        return RedirectToAction("GetAllDoctor");
                    }
                    foreach (var error in NewDoctorUser.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(user);
                }
                return View(user);
                //if (result > 0)
                //{
                //    TempData["SuccessMessage"] = "Doctor added successfully";
                //    return RedirectToAction("GetAllDoctor");
                //}
                //else
                //{
                //    TempData["ErrorMessage"] = "Failed to add doctor";
                //    return View(doctor);
                //}
            }
        }



        
        [HttpGet]
        public async Task<IActionResult> EditDoctor(int id)
{
    var doctor = await _doctorService.GetDoctorByIdAsync(id);
    if (doctor == null)
    {
        TempData["ErrorMessage"] = "Doctor not found"; // Set an error message if the doctor is not found
        return RedirectToAction("GetAllDoctor"); // Redirect to the list of doctors
    }

    // Return the doctor with only the specialty for editing
    return View(doctor);
}

[HttpPost]
public async Task<IActionResult> EditDoctor(int id, string specialty)
{
    // Validate the specialty input
    if (string.IsNullOrWhiteSpace(specialty))
    {
        ModelState.AddModelError("Specialty", "Specialty is required.");
        return View(new Doctor { DoctorId = id, Specialty = specialty }); // Return the view with the current specialty
    }

    // Retrieve the existing doctor
    var doctor = await _doctorService.GetDoctorByIdAsync(id);
    if (doctor == null)
    {
        TempData["ErrorMessage"] = "Doctor not found"; // Set an error message if the doctor is not found
        return RedirectToAction("GetAllDoctor"); // Redirect to the list of doctors
    }

    // Update the specialty
    doctor.Specialty = specialty;

    // Update the doctor in the database
    int result = await _doctorService.UpdateDoctorAsync(doctor);

    if (result > 0)
    {
        TempData["SuccessMessage"] = "Doctor's specialty updated successfully";
        return RedirectToAction("GetAllDoctor"); // Redirect to the list of doctors
    }
    else
    {
        TempData["ErrorMessage"] = "Failed to update doctor's specialty";
        return View(doctor); // Return the view with the current doctor model to show the error
    }
}
        
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            try
            {
                await _doctorService.DeleteDoctorAsync(id);
                return RedirectToAction("GetAllDoctor");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return RedirectToAction("GetAllDoctor");
            }
        }

        public async Task<IActionResult> DoctorDetails(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }
    }
}
