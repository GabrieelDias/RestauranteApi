using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestauranteApi.Data;
using RestauranteApi.Models;
using RestauranteApi.Repository;
using System.Xml.Linq;

namespace RestauranteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PratosController : ControllerBase
    {
        private readonly IPratosRepository _pratosRepository;

        public PratosController(IPratosRepository pratosRepo)
        {
            _pratosRepository = pratosRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(PratosModel pratos)
        {

            await _pratosRepository.SalvarPratos(pratos);
            return Ok(pratos);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PratosModel>>> FindAll()
        {
            var pratos = await _pratosRepository.FindAll();
            return Ok(pratos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PratosModel>> FindById(int id)
        {

            var pratos = await _pratosRepository.FindById(id);
            if (pratos == null)
            {
                return NotFound(new { message = $"Prato com Id {id} não encontrado" });
            }
            return Ok(pratos);
        }

        [HttpGet("busca/{name}")]
        public async Task<ActionResult<IEnumerable<PratosModel>>> FindByName(string name)
        {
            var pratos = await _pratosRepository.FindByName(name);
            if (pratos == null || !pratos.Any())
            {
                return NotFound(new { message = $"Prato com nome: {name} não encontrado" });
            }
            return Ok(pratos);
        }

        [HttpGet("filtrar/{categoria}")]
        public async Task<ActionResult<IEnumerable<PratosModel>>> FiltrarPratos(string categoria)
        {
            var pratos = await _pratosRepository.FiltrarPratos(categoria);
            if (pratos == null || !pratos.Any())
            {
                return NotFound(new { message = $"Categoria: {categoria} não encontrado" });
            }
            return Ok(pratos);
        }

        [HttpGet("disponiveis")]
        public async Task<ActionResult<IEnumerable<PratosModel>>> DisponiveisPratos()
        {
            var pratos = await _pratosRepository.DisponiveisPratos();
            return Ok(pratos);
        }

        [HttpPut("atualizar/{id}")]
        public async Task<ActionResult> Atualizar(PratosModel pratos, int id) 
        {
            var PratoExistente = await _pratosRepository.FindById(id);
            if(PratoExistente == null)
            {
                return NotFound(new {mensagem = $"Não foi possível atualizar prato. Id:{id} não encontrado."});
            }
            await _pratosRepository.AtualizarPratos(pratos, id);
            return Ok("Prato atualizado com sucesso.");
        }

        [HttpPut("{id:int}/ativar")]
        public async Task<ActionResult> AtivarPratos(int id)
        {
            var pratoExistente = await _pratosRepository.FindById(id);
            if (pratoExistente == null)
            {
                return NotFound(new { mensagem = "Prato com Id não encontrado." });
            }
            await _pratosRepository.AtivarPratos(id);
            return Ok("Prato ativado com sucesso.");
        }

        [HttpPut("{id:int}/desativar")]
        public async Task<ActionResult> DesativarPratos(int id)
        {
            var pratoExistente = await _pratosRepository.FindById(id);
            if (pratoExistente == null)
            {
                return NotFound(new { mensagem = $"Prato com Id {id} não encontrado." });
            }
            await _pratosRepository.DesativarPratos(id);
            return Ok("Prato desativado com sucesso.");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) 
        {
            var pratoExistente = await _pratosRepository.FindById(id);
            if(pratoExistente == null)
            {
                return NotFound(new { mensagem = $"Prato com ID {id} não encontrado." });
            }
            await _pratosRepository.DeletarPratos(id);
            return Ok("Prato deletado com sucesso.");
        }
    }
}
