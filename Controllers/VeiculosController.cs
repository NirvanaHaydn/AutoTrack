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
    }
}
