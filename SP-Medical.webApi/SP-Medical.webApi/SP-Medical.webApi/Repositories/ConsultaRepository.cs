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
    public class ConsultaRepository : IConsultaRepository
    {
        SpMedicalContext ctx = new SpMedicalContext();
        public void Atualizar(int id, Consultum NovaConsulta)
        {
            Consultum ConBuscado = ctx.Consulta.Find(id);

            if (NovaConsulta.Descricao != null)
            {
                ConBuscado.Descricao = NovaConsulta.Descricao;
            }

            ctx.Consulta.Update(ConBuscado);
            ctx.SaveChanges();
        }

        public Consultum BuscarPorId(int id)
        {
            return ctx.Consulta.FirstOrDefault(e => e.IdConsulta == id);
        }

        public void Cadastrar(Consultum NovaConsulta)
        {
            ctx.Consulta.Add(NovaConsulta);
            ctx.SaveChanges();
        }

        public List<Consultum> ConMedico(int id)
        {
            Medico MedicoBuscado = ctx.Medicos.FirstOrDefault(e => e.IdUsuario == id);


            return ctx.Consulta
               .Include(e => e.IdPacienteNavigation)
               .Include(e => e.IdSituacaoNavigation)
               .Where(e => e.IdMedico == MedicoBuscado.IdMedico)
               .ToList();
        }

        public List<Consultum> ConPaciente(int id)
        {
            Paciente PacienteBuscado = ctx.Pacientes.FirstOrDefault(e => e.IdUsuario == id);

            return ctx.Consulta
                .Include(e => e.IdMedicoNavigation)
                .Include(e => e.IdMedicoNavigation.IdClinicaNavigation)
                .Include(e => e.IdMedicoNavigation.IdEspecialidadeNavigation)
                .Include(e => e.IdSituacaoNavigation)
                .Where(e => e.IdPaciente == PacienteBuscado.IdPaciente)
                .ToList();
        }

        public void Deletar(int id)
        {
            Consultum ConBuscada = ctx.Consulta.Find(id);
            ctx.Consulta.Remove(ConBuscada);
            ctx.SaveChanges();
        }

        public List<Consultum> ListarCon()
        {
            return ctx.Consulta.ToList();
        }

        public List<Consultum> ListarTodos()
        {
            return ctx.Consulta
                 .Include(e => e.IdPacienteNavigation)
                 .Include(e => e.IdMedicoNavigation)
                 .Include(e => e.IdSituacaoNavigation)
                 .ToList();
        }

        public void Status(int id, string status)
        {
            Consultum consulta = ctx.Consulta
                .FirstOrDefault(e => e.IdConsulta == id);

            switch (status)
            {
                case "1":
                    consulta.IdSituacao = 1;
                    break;

                case "2":
                    consulta.IdSituacao = 2;
                    break;

                case "3":
                    consulta.IdSituacao = 3;
                    break;

                default:
                    consulta.IdSituacao = consulta.IdSituacao;
                    break;
            }

            ctx.Consulta.Update(consulta);
            ctx.SaveChanges();
        }
    }
}
