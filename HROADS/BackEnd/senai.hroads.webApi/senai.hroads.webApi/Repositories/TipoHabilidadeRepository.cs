using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {
        HroadsContext ctx = new HroadsContext();
        public List<TipoHabilidade> Listar()
        {
            return ctx.TipoHabilidades.ToList();
        }
    }
}
