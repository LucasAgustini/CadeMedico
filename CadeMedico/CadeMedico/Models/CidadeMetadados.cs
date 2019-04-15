using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMedico.Models
{
    [MetadataType(typeof(CidadeMetadados))]

    public class CidadeMetadados
    {
        [Required(ErrorMessage = "Informe a cidade")]
        [StringLength(3, ErrorMessage = "Nome inválido")]
        public String Nome { get; set; }

    }
}