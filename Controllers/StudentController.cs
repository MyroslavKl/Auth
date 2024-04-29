using Lab2.Models;
using Lab2.Unit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            var students = _unitOfWork.StudentRepository.GetAll();
            return View(students);
        }

        
        public async Task<ActionResult> Details(int id)
        {
            var student = await _unitOfWork.StudentRepository.GetAsync(id);
            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Student student)
        {
            await _unitOfWork.StudentRepository.InsertAsync(student);
            await _unitOfWork.Save();
            return RedirectToAction("Index");   
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Edit(int id)
        {
            var student = await _unitOfWork.StudentRepository.GetAsync(id);
            return View(student);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Edit(int id, Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            _unitOfWork.StudentRepository.Update(student);
            await _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(int id)
        {
            var student = await _unitOfWork.StudentRepository.GetAsync(id);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id,int s)
        {
            var student = await _unitOfWork.StudentRepository.GetAsync(id);
            _unitOfWork.StudentRepository.Delete(student);
            await _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
