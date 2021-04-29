using Microsoft.EntityFrameworkCore;
using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int id, Classe classeAtualizado)
        {
            Classe classeBuscado = ctx.Classes.Find(id);

            if (classeAtualizado.NomeClasse != null)
            {
                classeBuscado.NomeClasse = classeAtualizado.NomeClasse;
            }

            ctx.Classes.Update(classeBuscado);

            ctx.SaveChanges();
        }

        public Classe BuscarPorId(int id)
        {
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == id);
        }

        public void Cadastrar(Classe novoClasse)
        {
            ctx.Classes.Add(novoClasse);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Classe classeBuscado = ctx.Classes.Find(id);
            ctx.Classes.Remove(classeBuscado);

            ctx.SaveChanges();
        }

        public List<Classe> Listar()
        {
            return ctx.Classes.ToList();
        }
    }
}
