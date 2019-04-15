using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMedico.Models
{
    [MetadataType(typeof(EstadoMetadados))]

    public partial class Estado
    {

    }

    public class EstadoMetadados
    {
        //idPais chave estrangeira
        //idEstado chave primaria

        [Required(ErrorMessage = "Informe o estado")]
        [StringLength(2, ErrorMessage = "Nome inválido")]
        public String Estado { get; set; }

        [Required(ErrorMessage = "Informe a Sigla do estado")]
        [StringLength(2, ErrorMessage = "Sigla possui 2 caracteres")]
        public String Sigla { get; set; }


    }
}