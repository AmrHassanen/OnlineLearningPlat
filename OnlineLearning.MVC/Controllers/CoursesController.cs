using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineLearning.Entity.Entities;
using OnlineLearning.Service.Interfaces;
using OnlineLearning.Service.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLearning.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IUserService _userService;

        public CoursesController(ICourseService courseService, IUserService userService)
        {
            _courseService = courseService;
            _userService = userService;
        }

        // GET: /Courses/Index
        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return View(courses);
        }

        // GET: /Courses/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            var viewModel = new CourseViewModel
            {
                Title = course.Title,
                Description = course.Description,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                InstructorId = course.InstructorId,
                Instructor = course.Instructor
            };

            return View(viewModel);
        }

        // GET: /Courses/Create
        public async Task<IActionResult> Create()
        {
            await PopulateInstructorsDropDownList();
            return View();
        }

        // POST: /Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseViewModel model)
        {

            var course = new Course
            {
                Title = model.Title,
                Description = model.Description,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                InstructorId = model.InstructorId,
            };

            await _courseService.AddCourseAsync(course);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Courses/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            var model = new CourseViewModel
            {
                Title = course.Title,
                Description = course.Description,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                InstructorId = course.InstructorId
            };

            await PopulateInstructorsDropDownList();
            return View(model);
        }

        // POST: /Courses/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseViewModel model)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            course.Title = model.Title;
            course.Description = model.Description;
            course.StartDate = model.StartDate;
            course.EndDate = model.EndDate;
            course.InstructorId = model.InstructorId;

            await _courseService.UpdateCourseAsync(course);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Courses/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course); // Pass the course to the view for confirmation.
        }

        // POST: /Courses/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            await _courseService.DeleteCourseAsync(id);
            TempData["SuccessMessage"] = "Course deleted successfully."; // Optional: Success message.

            return RedirectToAction(nameof(Index));
        }

        // Helper method to populate the dropdown for instructors
        private async Task PopulateInstructorsDropDownList()
        {
            var instructors = await _userService.GetAllInstructorsAsync();
            ViewBag.Instructors = new SelectList(instructors, "Id", "FullName");
        }
    }
}
