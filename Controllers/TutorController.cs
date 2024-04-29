using Lab2.Models;
using Lab2.Unit;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class TutorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TutorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            var tutors = _unitOfWork.TutorRepository.GetAll();
            return View(tutors);
        }


        public async Task<ActionResult> Details(int id)
        {
            var tutor = await _unitOfWork.TutorRepository.GetAsync(id);
            return View(tutor);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Tutor tutor)
        {
            await _unitOfWork.TutorRepository.InsertAsync(tutor);
            await _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var tutor = await _unitOfWork.TutorRepository.GetAsync(id);
            return View(tutor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Tutor tutor)
        {
            if (id != tutor.TutorId)
            {
                return NotFound();
            }

            _unitOfWork.TutorRepository.Update(tutor);
            await _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(int id)
        {
            var tutor = await _unitOfWork.TutorRepository.GetAsync(id);
            return View(tutor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, int s)
        {
            var tutor = await _unitOfWork.TutorRepository.GetAsync(id);
            _unitOfWork.TutorRepository.Delete(tutor);
            await _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
