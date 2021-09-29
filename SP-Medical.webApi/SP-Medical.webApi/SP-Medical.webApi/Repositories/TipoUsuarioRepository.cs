using Microsoft.EntityFrameworkCore;
using SP_Medical.webApi.Contexts;
using SP_Medical.webApi.Domains;
using SP_Medical.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical.webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        SpMedicalContext ctx = new SpMedicalContext();
        public void Atualizar(int id, TipoUsuario NovoTipoUsuario)
        {
            TipoUsuario UTipoBuscado = ctx.TipoUsuarios.Find(id);

            if (NovoTipoUsuario.TituloTipoUsuario != null)
            {
                UTipoBuscado.TituloTipoUsuario = NovoTipoUsuario.TituloTipoUsuario;
            }

            ctx.TipoUsuarios.Update(UTipoBuscado);
            ctx.SaveChanges();
        }

        public void Cadastrar(TipoUsuario NovoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(NovoTipoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoUsuario UTipoBuscado = ctx.TipoUsuarios.Find(id);
            ctx.TipoUsuarios.Remove(UTipoBuscado);
            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }

        public List<TipoUsuario> ListarUser()
        {
            return ctx.TipoUsuarios.
               Include(e => e.Usuarios).ToList();
        }
    }
}
