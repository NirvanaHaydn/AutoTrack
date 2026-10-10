using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTrack.Models
{
    //classe que gerencia dados de um veiculo, pode ser pessoa, animal, objeto, etc.

    [Table("Veiculos")]
    public class Veiculo
    {
        [Key] //chave primaria e auto incrementavel
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")] //campo obrigatório tanto no front-end quanto no back-end
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Placa é obrigatório.")]  
        public string Placa { get; set; }

        [Required(ErrorMessage = "O campo Ano de Fabricação é obrigatório.")]
        public int AnoFabricacao { get; set; }

        [Required(ErrorMessage = "O campo Ano do Modelo é obrigatório.")]   
        public int AnoModelo { get; set; }
    }
}
