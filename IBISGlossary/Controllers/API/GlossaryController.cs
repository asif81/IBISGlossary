using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBISGlossary.Model;
using DataAccess.Repository.IRepository;
using Newtonsoft.Json;

namespace IBISGlossary
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlossaryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GlossaryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return Json(new { success = true, data = _unitOfWork.glossary.GetAllOrSearch() });
            }
            catch
            {
                return Json(new { success = false, message = "Error loading glossary!", data = "" });
            }
        }

        [HttpGet("GetBySearch")]
        public IActionResult GetBySearch(string Term)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Term))
                    return Json(new { success = true, data = _unitOfWork.glossary.GetAllOrSearch(s => s.OrderBy(s => s.Term)) });
                else
                    return Json(new { success = true, data = _unitOfWork.glossary.GetAllOrSearch(s=> s.OrderBy(s=>s.Term) ,s=>s.Term.Contains(Term)) });
            }
            catch
            {
                return Json(new { success = false, message = "Error loading glossary!", data = "" });
            }
        }

        [HttpDelete("Delete")]
        [Route("Delete/{id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                var objFromDb = _unitOfWork.glossary.Get(Id);

                if (objFromDb == null)
                {
                    return Json(new { success = false, message = "Glossary does not exist!" });
                }

                _unitOfWork.glossary.Remove(objFromDb);
                _unitOfWork.Save();

                return Json(new { success = true, message = "Deleted successfully!" });
            }
            catch
            {
                return Json(new { success = false, message = "Error deleting glossary!" });
            }
        }
    }
}
