using SP_Medical.webApi.Contexts;
using SP_Medical.webApi.Domains;
using SP_Medical.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpMedicalContext ctx = new SpMedicalContext();
        public void Atualizar(int id, Usuario NovoUsuario)
        {
            Usuario UsuarioBuscado = BuscarPorId(id);

            if (NovoUsuario.IdTipoUsuario > 0 && NovoUsuario.Email != null && NovoUsuario.Senha != null)
            {
                UsuarioBuscado.IdTipoUsuario = NovoUsuario.IdTipoUsuario;
                UsuarioBuscado.NomeUsuario = NovoUsuario.NomeUsuario;
                UsuarioBuscado.Email = NovoUsuario.Email;
                UsuarioBuscado.Senha = NovoUsuario.Senha;
                ctx.Usuarios.Update(UsuarioBuscado);
                ctx.SaveChanges();
            }
            
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == id);
        }

        public void Cadastrar(Usuario NovoUsuario)
        {
            ctx.Add(NovoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario UsuarioBuscado = ctx.Usuarios.Find(id);
            ctx.Usuarios.Remove(UsuarioBuscado);
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.Email == email && e.Senha == senha);
        }
    }
}
