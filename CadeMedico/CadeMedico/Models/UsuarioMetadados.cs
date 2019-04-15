using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMedico.Models
{
    [MetadataType(typeof(UsuarioMetadados))]
    public partial class Usuarios
    {

    }

    public class UsuarioMetadados
    {

        //IDusuario auto
        [Required(ErrorMessage = "Obrigatório informar o Nome")]
        [StringLength(4, ErrorMessage = "O Nome deve possuir um número válido de caracteres")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Login")]
        [StringLength(2, ErrorMessage = "O login deve possuir um número válido de caracteres")]
        public String Loginn { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a Senha")]
        [StringLength(4, ErrorMessage = "Tamanho mínimo de 4 caracteres")]
        public String Senha { get; set; }

        [StringLength(6, ErrorMessage = "Email inválido")]
        public String Email { get; set; }
    }
}