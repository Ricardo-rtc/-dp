using SP_Medical.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical.webApi.Interfaces
{
    interface IConsultaRepository
    {
        List<Consultum> ListarTodos();
        List<Consultum> ListarCon();
        List<Consultum> ListarMinhas(int id);
    

        Consultum BuscarPorId(int id);
        void Cadastrar(Consultum NovaConsulta);
        void Deletar(int id);
        void Atualizar(int id, Consultum NovaConsulta);
        void AtualizarDescricao(int id, string DescricaoAtualizada);
        void Situacao(int id, string status);
    }
}
