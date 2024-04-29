using Lab2.Data;
using Lab2.Models;
using Lab2.Repositories.Contracts;
using Lab2.Unit;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var courses = _unitOfWork.CourseRepository.GetAll();
            return View(courses);
        }


        public async Task<ActionResult> Details(int id)
        {
            var course = await _unitOfWork.CourseRepository.GetAsync(id);
            return View(course);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Course course)
        {
            await _unitOfWork.CourseRepository.InsertAsync(course);
            await _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(int id)
        {
            var course = await _unitOfWork.CourseRepository.GetAsync(id);
            return View(course);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            _unitOfWork.CourseRepository.Update(course);
            await _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(int id)
        {
            var course = await _unitOfWork.CourseRepository.GetAsync(id);
            return View(course);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, int s)
        {
            var course = await _unitOfWork.CourseRepository.GetAsync(id);
            _unitOfWork.CourseRepository.Delete(course);
            await _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }


        
    }
}
