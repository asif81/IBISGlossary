using IBISGlossary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IBISGlossary.DataAccess.Repository
{
    public interface IGlossaryRepository
    {
        public void Update(Glossary glossary);
    }
}
