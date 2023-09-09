using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage ="O nome é obrigatório")]
        [MinLength(3,ErrorMessage = "O campo Nome deve ser um tipo de cadeia de caracteres ou matriz com um comprimento mínimo de '3'.")]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Name { get; set; }
    }
}
