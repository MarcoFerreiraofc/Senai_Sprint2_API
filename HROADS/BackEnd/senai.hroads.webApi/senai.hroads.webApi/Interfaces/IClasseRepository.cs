using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClasseRepository
    {
        List<Classe> Listar();

        Classe BuscarPorId(int id);

        void Cadastrar(Classe novoClasse);

        void Atualizar(int id, Classe classeAtualizado);

        void Deletar(int id);
    }
}
