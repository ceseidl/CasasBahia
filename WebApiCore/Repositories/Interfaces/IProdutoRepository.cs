using Microsoft.AspNetCore.Mvc;
using WebApiCore.Data.Entities;

namespace WebApiCore.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        Task<ActionResult<IEnumerable<Produto>>> GetProduto();
        Task<ActionResult<Produto>> GetProduto(int id);
        Task<bool> PutProduto(int id, Produto produto);
        Task<int> PostProduto(Produto produto);
        Task<bool> DeleteProduto(int id);
    }
}
