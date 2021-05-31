using DataAccess.Repository.IRepository;
using IBISGlossary.DataAccess;
using IBISGlossary.DataAccess.Repository;
using IBISGlossary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            glossary = new GlossaryRepository(applicationDbContext);
        }

        public IGlossaryRepository glossary { get; private set; }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }
    }
}
