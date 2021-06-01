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
            return Json(new { data = _unitOfWork.glossary.GetAllOrSearch() });
        }

        [HttpGet("GetBySearch")]
        public IActionResult GetBySearch(string Term)
        {
            if (string.IsNullOrWhiteSpace(Term))
                return Json(new { data = _unitOfWork.glossary.GetAllOrSearch() });
            else
                return Json(new { data = _unitOfWork.glossary.GetAllOrSearch(s=>s.Term.Contains(Term)) });
        }

        [HttpDelete("Delete")]
        [Route("Delete/{id}")]
        public IActionResult Delete(int Id)
        {
            var objFromDb = _unitOfWork.glossary.Get(Id);

            if (objFromDb == null)
            {
                return Json(new { success = false, error = "Error deleting glossary!" });
            }

            _unitOfWork.glossary.Remove(objFromDb);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Deleted successfully!" });
        }
    }
}
