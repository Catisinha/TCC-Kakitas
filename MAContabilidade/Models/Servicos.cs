using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAContabilidade.Models;

[Table("Servicos")]
public class Servicos
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
        
    [Required(ErrorMessage = "Por favor, informe o nome do serviço")]
    [StringLength(30, ErrorMessage = "O Nome deve possuir no máximo 30 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Por favor, informe a descrição do serviço")]
    [StringLength(200, ErrorMessage = "A descrição deve possuir no máximo 200 caracteres")]

    public string Descricao { get; set; }
}