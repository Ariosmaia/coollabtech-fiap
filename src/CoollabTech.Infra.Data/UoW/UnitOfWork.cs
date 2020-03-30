using CoollabTech.Domain.Interfaces;
using CoollabTech.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoollabTech.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoollabTechContext _context;

        public UnitOfWork(CoollabTechContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
