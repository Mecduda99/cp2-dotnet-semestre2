using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CP2.Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ApplicationContext _context;

        public VendedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        // Cria um novo Vendedor
        public async Task<VendedorEntity> SalvarDados(VendedorEntity vendedor)
        {
            await _context.Vendedores.AddAsync(vendedor);
            await _context.SaveChangesAsync();
            return vendedor;
        }

        // Obtém todos os Vendedores
        public async Task<IEnumerable<VendedorEntity>> ObterTodos()
        {
            return await _context.Vendedores.ToListAsync();
        }

        // Obtém um Vendedor pelo ID
        public async Task<VendedorEntity?> ObterPorId(int id)
        {
            return await _context.Vendedores.FindAsync(id);
        }

        // Atualiza um Vendedor
        public async Task<VendedorEntity?> EditarDados(int id, VendedorEntity vendedor)
        {
            var existingVendedor = await ObterPorId(id);
            if (existingVendedor == null) return null;

            existingVendedor.Nome = vendedor.Nome;
            existingVendedor.Email = vendedor.Email;
            existingVendedor.Telefone = vendedor.Telefone;
            existingVendedor.DataNascimento = vendedor.DataNascimento;
            existingVendedor.Endereco = vendedor.Endereco;
            existingVendedor.DataContratacao = vendedor.DataContratacao;
            existingVendedor.ComissaoPercentual = vendedor.ComissaoPercentual;
            existingVendedor.MetaMensal = vendedor.MetaMensal;
            existingVendedor.CriadoEm = vendedor.CriadoEm;

            await _context.SaveChangesAsync();
            return existingVendedor;
        }

        // Deleta um Vendedor
        public async Task<VendedorEntity?> DeletarDados(int id)
        {
            var vendedor = await ObterPorId(id);
            if (vendedor == null) return null;

            _context.Vendedores.Remove(vendedor);
            await _context.SaveChangesAsync();
            return vendedor;
        }
    }
}
