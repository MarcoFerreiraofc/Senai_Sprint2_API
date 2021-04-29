using senai.hroads.webApi.Contexts;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        HroadsContext ctx = new HroadsContext();
        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuarios.ToList();
        }
    }
}
