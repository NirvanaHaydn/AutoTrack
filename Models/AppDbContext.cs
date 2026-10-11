using Microsoft.EntityFrameworkCore;

namespace AutoTrack.Models
{
    //Classe de contexto de dados para o Entity Framework Core.
    //Gera minha tabela no banco de dados com base nas minhas classes de modelo.
    //Utilitario responsável por pegar todas as classes que eu configurei e gerar as tabelas no banco de dados.
    public class AppDbContext : DbContext //minha classe AppDbContext herda todas as características e propriedades da classe DbContext - injeção de dependencia
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        //passa as configurações pra mim, que eu configuro o banco de dados pra você

        public DbSet<Veiculo> Veiculos { get; set; } 


    }
}
