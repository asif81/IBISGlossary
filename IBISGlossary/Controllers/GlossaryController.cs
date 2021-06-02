using DataAccess.Repository.IRepository;
using IBISGlossary.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBISGlossary.Controllers
{
    public class GlossaryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GlossaryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upsert(int? Id)
        {
            Glossary glossary = new Glossary();
            try
            {                
                if (Id == null)
                {
                    return View(glossary);
                }

                glossary = _unitOfWork.glossary.Get(Id.GetValueOrDefault());

                if (glossary == null)
                {
                    TempData["errorMessage"] = "Glossary with this Id does not exists!";
                    return View(glossary);
                }

                return View(glossary);
            }
            catch
            {
                TempData["errorMessage"] = "Error loading glossary!";
                return View(glossary);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Glossary glossary)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (glossary.Id == 0)
                    {
                        _unitOfWork.glossary.Add(glossary);
                    }
                    else
                    {
                        _unitOfWork.glossary.Update(glossary);
                    }

                    _unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
                return View(glossary);
            }
            catch
            {
                TempData["errorMessage"] = "Error updating glossary!";
                return View(glossary);
            }
        }
    }
}
