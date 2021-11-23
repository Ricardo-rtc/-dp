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
    public class PacienteRepository : IPacienteRepository
    {
        SpMedicalContext ctx = new SpMedicalContext();
        public void Atualizar(int id, Paciente NovoPaciente)
        {
            Paciente PacienteBuscado = ctx.Pacientes.Find(id);

            if (NovoPaciente.NomePaciente != null)
            {
                PacienteBuscado.NomePaciente = NovoPaciente.NomePaciente;
            }

            if (NovoPaciente.Telefone != null)
            {
                PacienteBuscado.Telefone = NovoPaciente.Telefone;
            }

            ctx.Pacientes.Update(PacienteBuscado);
            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(int id)
        {
            return ctx.Pacientes.FirstOrDefault(e => e.IdPaciente == id);
        }

        public void Cadastrar(Paciente NovoPaciente)
        {
            ctx.Pacientes.Add(NovoPaciente);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Paciente PacienteBuscado = ctx.Pacientes.Find(id);
            ctx.Pacientes.Remove(PacienteBuscado);
            ctx.SaveChanges();
        }

        public List<Paciente> Listar()
        {
            return ctx.Pacientes.ToList();
        }

        public List<Paciente> ListarTudo()
        {
            return ctx.Pacientes
                .Include(e => e.Consulta)
                .ToList();
        }
    }
}
