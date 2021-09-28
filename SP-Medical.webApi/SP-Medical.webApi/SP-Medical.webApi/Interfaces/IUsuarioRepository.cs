using SP_Medical.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);
        List<Usuario> Listar();
        Usuario BuscarPorId(int id);
        void Cadastrar(Usuario NovoUsuario);
        void Deletar(int id);
        void Atualizar(int id, Usuario NovoUsuario);
    }
}
