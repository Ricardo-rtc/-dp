using SP_Medical.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical.webApi.Interfaces
{
    interface IPacienteRepository
    {
        List<Paciente> Listar();
        List<Paciente> ListarTudo();
        Paciente BuscarPorId(int id);
        void Cadastrar(Paciente NovoPaciente);
        void Deletar(int id);
        void Atualizar(int id, Paciente NovoPaciente);
    }
}
