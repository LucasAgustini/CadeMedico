using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMedico.Models
{
    [MetadataType(typeof(EspecialidadeMetadados))]
    public partial class Especialidades
    {

    }

    public class EspecialidadeMetadados
    {
        //IDespecialidade chave primaria
        [Required(ErrorMessage = "Informe a especialidade")]
        [StringLength(5, ErrorMessage = "Especialidade inválida")]
        public String Nome { get; set; }

    }
}