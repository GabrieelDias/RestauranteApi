using RestauranteApi.Controllers;
using RestauranteApi.Models;

namespace RestauranteApi.Repository
{
    public interface IPratosRepository
    {

        public Task<IEnumerable<PratosModel>> FindAll();
        public Task<PratosModel> FindById(int id);
        public Task<IEnumerable<PratosModel>> FindByName(string name);
        public Task<IEnumerable<PratosModel>> DisponiveisPratos();
        public Task<IEnumerable<PratosModel>> FiltrarPratos(string categoria);

        public Task AtualizarPratos(PratosModel pratos, int id);
        public Task<PratosModel> SalvarPratos(PratosModel pratos);
        public Task AtivarPratos(int id);
        public Task DesativarPratos(int id);
        public Task DeletarPratos(int id);

    }
}
