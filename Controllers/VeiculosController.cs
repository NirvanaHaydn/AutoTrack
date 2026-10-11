using AutoTrack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoTrack.Controllers
{
    public class VeiculosController : Controller 
    {
        private readonly AppDbContext _context;
        public VeiculosController(AppDbContext context)
        {
           _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Veiculos.ToListAsync(); //retorna os dados da tabela veiculos
            return View(dados); //minha view vai receber os dados da tabela veiculos
        } //recebe uma rota e retorna uma view para o usuário

        public IActionResult Create()
        {
            return View(); //exiba o formulario para o meu usuario
        }

        [HttpPost]
        public async Task<IActionResult> Create(Veiculo veiculo)
        {
            if (ModelState.IsValid)//verifica se o modelo de dados é valido, se sim ele faz o cadastro do veiculo
            {
                _context.Veiculos.Add(veiculo); //adiciona o veiculo no banco de dados
                await _context.SaveChangesAsync();
                return RedirectToAction("Index"); //redireciona para a rota index
            }
            return View(); //receber requisiçao via post com os dados preenchidos
        }
        public async Task<IActionResult> Edit(int? id) //recebe o id para fazer o processamento dos dados
        {
            if(id == null) 
                return NotFound(); 
                var dados = await _context.Veiculos.FindAsync(id); //busca o veiculo no banco de dados
            
            if(dados == null) 
                return NotFound(); 

            return View(dados); //exiba o formulario para o meu usuario
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Veiculo veiculo)
        {
            if(id != veiculo.Id)
                return NotFound(); //não posso alterar o id do veiculo pois é chave primaria, se o id for diferente do id do veiculo ele retorna not found

            if (ModelState.IsValid)
            {
                _context.Veiculos.Update(veiculo); 
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(); 
        }

        public async Task<IActionResult> Details(int? id)//interrogação pois pode receber nulo
        {
            if(id==null)
                return NotFound(); //se o id for nulo ele retorna not found 
            var dados = await _context.Veiculos.FindAsync(id); //busca o veiculo no banco de dados
            if(dados == null)
                return NotFound(); //se o veiculo não for encontrado ele retorna not found
            return View(dados); //exiba o formulario para o meu usuario

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();  
            var dados = await _context.Veiculos.FindAsync(id); 
            if (dados == null)
                return NotFound(); 
            return View(dados); 

        }

        [HttpPost, ActionName("Delete")] //ActionName é usado para mapear a ação do método para o nome da ação Delete
        public async Task<IActionResult> DeleteConfirmed(int? id) //rota para confirmar que quer deletar o veiculo do banco de dados
        {
            if (id == null)
                return NotFound();  
            var dados = await _context.Veiculos.FindAsync(id); 
            if (dados == null)
                return NotFound();
            _context.Veiculos.Remove(dados); //remove o veiculo do banco de dados
            await _context.SaveChangesAsync(); //salva as alterações no banco de dados

            return RedirectToAction("Index"); //redireciona para a rota index 

        }



    }
}
