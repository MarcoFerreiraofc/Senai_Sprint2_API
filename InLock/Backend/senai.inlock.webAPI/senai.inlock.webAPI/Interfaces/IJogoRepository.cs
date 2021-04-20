using senai.inlock.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.Interfaces
{
    interface IJogoRepository
    {
        List<JogoDomain> Listar();

        JogoDomain BuscarPorId(int id);

        void Atualizar(int id, JogoDomain jogoAtualizado);

        void Cadastrar(JogoDomain novoJogo);

        void Deletar(int id);

        JogoDomain BuscarPorNome(string nome);
    }
}
