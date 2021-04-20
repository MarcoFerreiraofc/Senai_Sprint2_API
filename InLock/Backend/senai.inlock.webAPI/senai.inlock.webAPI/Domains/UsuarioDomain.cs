using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.Domains
{
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "Email do usuário obrigatório!")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(ErrorMessage = "Senha do usuário obrigatório!")]
        [DataType(DataType.Password)]
        public string senha { get; set; }

        public int idTipoUsuario { get; set; }

        public TipoUsuarioDomain tipoUsuario { get; set; }
    }
}
