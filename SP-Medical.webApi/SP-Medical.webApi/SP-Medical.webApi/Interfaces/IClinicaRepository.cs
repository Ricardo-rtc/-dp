using SP_Medical.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical.webApi.Interfaces
{
    interface IClinicaRepository
    {
        
        List<Clinica> ListarTodos();

        Clinica BuscarPorId(int idClinica);

        void Cadastrar(Clinica novaClinica);

        void Atualizar(int idClinica, Clinica clinicaAtualizada);

        void Deletar(int idClinica);
    }
}
