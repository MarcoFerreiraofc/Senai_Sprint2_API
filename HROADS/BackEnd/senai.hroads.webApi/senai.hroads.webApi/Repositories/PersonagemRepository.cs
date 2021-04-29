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
    public class PersonagemRepository : IPersonagemRepository
    {
        HroadsContext ctx = new HroadsContext();
        public void Atualizar(int id, Personagem personagemAtualizado)
        {
            Personagem personagemBuscado = ctx.Personagems.Find(id);

            if (personagemAtualizado.NomePersonagem != null)
            {
                personagemBuscado.NomePersonagem = personagemAtualizado.NomePersonagem;
            }

            if(personagemAtualizado.IdClasse != null)
            {
                personagemBuscado.IdClasse = personagemAtualizado.IdClasse;
            }

            if (personagemAtualizado.VidaMaxima != null)
            {
                personagemBuscado.VidaMaxima = personagemAtualizado.VidaMaxima;
            }

            if (personagemAtualizado.ManaMaxima != null)
            {
                personagemBuscado.ManaMaxima = personagemAtualizado.ManaMaxima;
            }

            personagemBuscado.DataAtualizacao = DateTime.Now;

            ctx.Personagems.Update(personagemBuscado);

            ctx.SaveChanges();
        }

        public Personagem BuscarPorId(int id)
        {
            return ctx.Personagems.Include(p => p.IdClasseNavigation).FirstOrDefault(h => h.IdPersonagem == id);
        }

        public void Cadastrar(Personagem novoPersonagem)
        {
            novoPersonagem.DataCriacao = DateTime.Now;

            ctx.Personagems.Add(novoPersonagem);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Personagem personagemBuscado = ctx.Personagems.Find(id);
            ctx.Personagems.Remove(personagemBuscado);

            ctx.SaveChanges();
        }

        public List<Personagem> Listar()
        {
            return ctx.Personagems.Include(p => p.IdClasseNavigation).ToList();
        }
    }
}
