using senai.inlock.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.Interfaces
{
    interface IEstudioRepository
    {
        List<EstudioDomain> Listar();

        EstudioDomain BuscarPorId(int id);

        void Atualizar(int id, EstudioDomain estudioAtualizado);

        void Cadastrar(EstudioDomain novoEstudio);

        void Deletar(int id);

        EstudioDomain BuscarPorNome(string nome);
    }
}
