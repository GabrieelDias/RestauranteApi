using Microsoft.EntityFrameworkCore;
using RestauranteApi.Data;
using RestauranteApi.Models;
using RestauranteApi.Repository;
using System.Collections;

namespace RestauranteApi.Services
{
    public class PratosService : IPratosRepository
    {
        private readonly AppDbContext _appDbContext;

        public PratosService(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }
    
        public async Task<IEnumerable<PratosModel>> FindAll()
        {
            return await _appDbContext.Prato.ToListAsync();
        }
    
        public async Task<PratosModel> FindById(int id)
        {
            return await _appDbContext.Prato.FindAsync(id);
        }
    
        public async Task<IEnumerable<PratosModel>> FindByName(string name)
        {
            return await _appDbContext.Prato.Where(p => p.Nome.Contains(name)).ToListAsync();
        }

        public async Task<IEnumerable<PratosModel>> DisponiveisPratos()
        {
            return await _appDbContext.Prato.Where(p => p.Disponivel).ToListAsync();
        }
        public async Task<IEnumerable<PratosModel>> FiltrarPratos(string categoria) 
        {
            var todos = await _appDbContext.Prato.ToListAsync();
            return todos.Where(p => p.Categoria.Any(c => c.ToUpper() == categoria.ToUpper()));
        }

        public async Task<PratosModel> SalvarPratos(PratosModel pratos)
        {
            _appDbContext.Prato.Add(pratos);
            await _appDbContext.SaveChangesAsync();
            return pratos;
        }

        public async Task AtualizarPratos(PratosModel pratos, int id)
        {
            try
            {
                var prato = await _appDbContext.Prato.FindAsync(id);

                if (prato == null) return;

                prato.Nome = pratos.Nome;
                prato.Preco = pratos.Preco;
                prato.Disponivel = pratos.Disponivel;

                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception e) 
            {
                throw;
            }
        }

        public async Task AtivarPratos(int id) 
        {
            var prato = await _appDbContext.Prato.FindAsync(id);
            if(prato != null)
            {
                prato.Disponivel = true;
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task DesativarPratos(int id) 
        {
            var prato = await _appDbContext.Prato.FindAsync(id);
            if (prato != null) {
                prato.Disponivel = false;
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task DeletarPratos(int id) 
        {
            var prato = await _appDbContext.Prato.FindAsync(id);
            if(prato != null)
            {
                _appDbContext.Prato.Remove(prato);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
