using System.ComponentModel.DataAnnotations;

namespace RestauranteApi.Models
{
    public class PratosModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do prato é obrigatório.")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 30 caracteres.")]
        public string Nome { get; set; }
        
        [Range(0.01, 9999.99, ErrorMessage = "O preço deve ser maior que zero.")]
        public double Preco { get; set; }
        
        public bool Disponivel { get; set; }
        public List<string> Categoria { get; set; } = ["Entrada", "Prato Principal", "Sobremesa", "Lanche", "Bebida"];
    }
}
