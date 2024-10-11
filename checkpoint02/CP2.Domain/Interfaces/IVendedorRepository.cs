using CP2.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CP2.Domain.Interfaces
{
    public interface IVendedorRepository
    {
        Task<VendedorEntity> SalvarDados(VendedorEntity vendedor);
        Task<IEnumerable<VendedorEntity>> ObterTodos();
        Task<VendedorEntity?> ObterPorId(int id);
        Task<VendedorEntity?> EditarDados(int id, VendedorEntity vendedor);
        Task<VendedorEntity?> DeletarDados(int id);
    }
}
