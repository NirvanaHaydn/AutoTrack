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
    }
}
