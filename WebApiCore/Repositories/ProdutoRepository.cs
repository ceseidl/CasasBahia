using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApiCore.Data;
using WebApiCore.Data.Entities;
using WebApiCore.Externals;
using WebApiCore.Externals.Interfaces;
using WebApiCore.Repositories.Interfaces;

namespace WebApiCore.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IKafkaServices _kafka;


        public ProdutoRepository(ApplicationDbContext context, IKafkaServices kafka)
        {
            _context = context;
            _kafka = kafka;
        }



        public async Task<ActionResult<IEnumerable<Produto>>> GetProduto()
        {
            return await _context.Produto.AsNoTracking().ToListAsync();
        }
        public async Task<bool> PutProduto(int id, Produto produto)
        {
            

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                {
                    return false;
                }
                else
                    throw;
                
            }

           
        }
        public async Task<int> PostProduto(Produto produto)
        {
            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();
            _kafka.Publicar(produto);
            return produto.Id;
        }


        public async Task<bool> DeleteProduto(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return false; 
            }

            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.Id == id);
        }

        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            return produto;
        }
    }
}
