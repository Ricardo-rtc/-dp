using SP_Medical.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical.webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();
        List<TipoUsuario> ListarUser();
        void Cadastrar(TipoUsuario NovoTipoUsuario);
        void Deletar(int id);
        void Atualizar(int id, TipoUsuario NovoTipoUsuario);
    }
}
