using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP2.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationContext _context;

        public FornecedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        // Cria um novo Fornecedor
        public async Task<FornecedorEntity> SalvarDados(FornecedorEntity fornecedor)
        {
            await _context.Forcedores.AddAsync(fornecedor);
            await _context.SaveChangesAsync();
            return fornecedor;
        }

        // Obtém todos os Fornecedores
        public async Task<IEnumerable<FornecedorEntity>> ObterTodos()
        {
            return await _context.Forcedores.ToListAsync();
        }

        // Obtém um Fornecedor pelo ID
        public async Task<FornecedorEntity?> ObterPorId(int id)
        {
            return await _context.Forcedores.FindAsync(id);
        }

        // Atualiza um Fornecedor
        public async Task<FornecedorEntity?> EditarDados(int id, FornecedorEntity fornecedor)
        {
            var existingFornecedor = await ObterPorId(id);
            if (existingFornecedor == null) return null;

            existingFornecedor.Nome = fornecedor.Nome;
            existingFornecedor.CNPJ = fornecedor.CNPJ;
            existingFornecedor.Endereco = fornecedor.Endereco;
            existingFornecedor.Telefone = fornecedor.Telefone;
            existingFornecedor.Email = fornecedor.Email;
            existingFornecedor.CriadoEm = fornecedor.CriadoEm;

            await _context.SaveChangesAsync();
            return existingFornecedor;
        }

        // Deleta um Fornecedor
        public async Task<FornecedorEntity?> DeletarDados(int id)
        {
            var fornecedor = await ObterPorId(id);
            if (fornecedor == null) return null;

            _context.Forcedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
            return fornecedor;
        }
    }
}
