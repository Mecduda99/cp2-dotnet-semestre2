using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CP2.Infrastructure.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly DbContext _context;

        public VendedorRepository(DbContext context)
        {
            _context = context;
        }

        public VendedorEntity? ObterPorId(int id)
        {
            return _context.Set<VendedorEntity>().Find(id);
        }

        public IEnumerable<VendedorEntity> ObterTodos()
        {
            return _context.Set<VendedorEntity>().ToList();
        }

        public VendedorEntity Inserir(VendedorEntity vendedor)
        {
            _context.Set<VendedorEntity>().Add(vendedor);
            _context.SaveChanges();
            return vendedor;
        }

        public VendedorEntity Atualizar(VendedorEntity vendedor)
        {
            _context.Set<VendedorEntity>().Update(vendedor);
            _context.SaveChanges();
            return vendedor;
        }

        public VendedorEntity? DeletarDados(int id)
        {
            var vendedor = _context.Set<VendedorEntity>().Find(id);
            if (vendedor == null) return null;

            _context.Set<VendedorEntity>().Remove(vendedor);
            _context.SaveChanges();
            return vendedor;
        }
    }
}
