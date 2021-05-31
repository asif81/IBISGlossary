using IBISGlossary.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGlossaryRepository glossary { get; }
        void Save();
    }
}
