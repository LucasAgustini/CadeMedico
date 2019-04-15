using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMedico.Models
{
    [MetadataType(typeof(PaisMetadados))]

    public class PaisMetadados
    {
        [Required(ErrorMessage = "Informe o país")]
        [StringLength(2, ErrorMessage = "Nome inválido")]
        public String Pais { get; set; }

        [Required(ErrorMessage = "Informe a Sigla do país")]
        [StringLength(2, ErrorMessage = "Sigla possui 2 caracteres")]
        public String Sigla { get; set; }

        //idPais //chave primaria

    }
}