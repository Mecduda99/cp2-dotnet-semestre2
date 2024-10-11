using CP2.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CP2.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<FornecedorEntity> SalvarDados(FornecedorEntity fornecedor);
        Task<IEnumerable<FornecedorEntity>> ObterTodos();
        Task<FornecedorEntity?> ObterPorId(int id);
        Task<FornecedorEntity?> EditarDados(int id, FornecedorEntity fornecedor);
        Task<FornecedorEntity?> DeletarDados(int id);
    }
}
