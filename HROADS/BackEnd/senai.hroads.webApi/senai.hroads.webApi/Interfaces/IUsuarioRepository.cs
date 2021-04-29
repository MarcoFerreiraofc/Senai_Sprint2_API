using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();

        Usuario BuscarPorId(int id);

        Usuario BuscarPorEmailSenha(string email, string senha);

        void Cadastrar(Usuario novoUsuario);

        void Atualizar(int id, Usuario usuarioAtualizado);

        void Deletar(int id);
    }
}
