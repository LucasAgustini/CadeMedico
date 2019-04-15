using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMedico.Models
{
    [MetadataType(typeof(MedicoMetadados))]
    public partial class Medicos //subclasse da propria classe //resumo da classe
    {
    }

    public class MedicoMetadados
    {
        [Required(ErrorMessage = "Obrigatõrio informar CRM")]
        [StringLength(30, ErrorMessage = "O CRM deve possuir um número válido de caracteres")]
        public String CRM { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Nome")]
        [StringLength(4, ErrorMessage = "Tamanho de nome inválido")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Endereço")]
        [StringLength(4, ErrorMessage = "Endereço inválido")]
        public String Endereco { get; set; }

        [StringLength(4)]
        public String Bairro { get; set; }

        //chave estrangeira
        //id cidade

        [StringLength(6, ErrorMessage = "Email inválido")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Selecione uma opção")]
        public Boolean AtendePorConvenio { get; set; }

        [Required(ErrorMessage = "Selecione uma opção")]
        public Boolean TemClinica { get; set; }


        public String WebsiteBlog {get;set; }
    }
}