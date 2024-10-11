using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CP2.Infrastructure.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly DbContext _context;

        public FornecedorRepository(DbContext context)
        {
            _context = context;
        }

        public FornecedorEntity? ObterPorId(int id)
        {
            return _context.Set<FornecedorEntity>().Find(id);
        }

        public IEnumerable<FornecedorEntity> ObterTodos()
        {
            return _context.Set<FornecedorEntity>().ToList();
        }

        public FornecedorEntity Inserir(FornecedorEntity fornecedor)
        {
            _context.Set<FornecedorEntity>().Add(fornecedor);
            _context.SaveChanges();
            return fornecedor;
        }

        public FornecedorEntity Atualizar(FornecedorEntity fornecedor)
        {
            _context.Set<FornecedorEntity>().Update(fornecedor);
            _context.SaveChanges();
            return fornecedor;
        }

        public FornecedorEntity? DeletarDados(int id)
        {
            var fornecedor = _context.Set<FornecedorEntity>().Find(id);
            if (fornecedor == null) return null;

            _context.Set<FornecedorEntity>().Remove(fornecedor);
            _context.SaveChanges();
            return fornecedor;
        }
    }
}
