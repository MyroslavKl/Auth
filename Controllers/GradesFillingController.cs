using Lab2.Models;
using Lab2.Unit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Controllers
{
    public class GradesFillingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public GradesFillingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var students = _unitOfWork.StudentRepository.GetAll().ToList();
            return View(students);
        }

        [HttpPost]
        public async Task<ActionResult> AssignGrades(List<int> studentIds, double value)
        {
            foreach (var studentId in studentIds)
            {
                var student = await  _unitOfWork.StudentRepository.GetAsync(studentId);

                if (student != null)
                {
                    var grade = new Grade { Value = value };

                    var gradeStudent = new GradeStudent
                    {
                        Grade = grade,
                        Student = student
                    };

                    await _unitOfWork.GradeRepository.InsertAsync(grade);
                    await _unitOfWork.GradeStudentsRepository.InsertAsync(gradeStudent);
                }
            }

            await _unitOfWork.Save();

            return RedirectToAction("Index");
        }

    }
}
