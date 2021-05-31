using DataAccess.Repository;
using IBISGlossary.DataAccess.Repository;
using IBISGlossary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IBISGlossary.DataAccess.Repository
{
    public class GlossaryRepository : Repository<Glossary>, IGlossaryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public GlossaryRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Update(Glossary glossary)
        {
            var objFromDb = _applicationDbContext.glossaries.FirstOrDefault(g => g.Id == glossary.Id);
            objFromDb.Term = glossary.Term;
            objFromDb.Definition = glossary.Definition;

            _applicationDbContext.SaveChanges();
        }
    }
}
