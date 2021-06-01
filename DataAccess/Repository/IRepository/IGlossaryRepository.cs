using DataAccess.Repository.IRepository;
using IBISGlossary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBISGlossary.DataAccess.Repository
{
    public interface IGlossaryRepository : IRepository<Glossary>
    {
        public void Update(Glossary glossary);
    }
}
