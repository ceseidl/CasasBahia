using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApiCore.Data.Entities
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [StringLength(maximumLength: 50)]
        [Required]
        public string Nome { get; set; }
        [Required]
        [Precision(10, 4)]
        public decimal Preco {  get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }



    }
}
