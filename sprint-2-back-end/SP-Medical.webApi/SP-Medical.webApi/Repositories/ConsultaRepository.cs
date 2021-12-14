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
            Consultum ConBuscado = BuscarPorId(id);

            if (NovaConsulta.IdPaciente > 0 && NovaConsulta.IdMedico > 0 && NovaConsulta.IdSituacao > 0 && NovaConsulta.DataConsulta != DateTime.Now && NovaConsulta.Descricao != null)
            {
                ConBuscado.IdPaciente = NovaConsulta.IdPaciente;
                ConBuscado.IdMedico = NovaConsulta.IdMedico;
                ConBuscado.IdSituacao = NovaConsulta.IdSituacao;
                ConBuscado.DataConsulta = NovaConsulta.DataConsulta;
                ConBuscado.Descricao = NovaConsulta.Descricao;

                ctx.Consulta.Update(ConBuscado);

                ctx.SaveChanges();
            }

         
        }
        public void AtualizarDescricao (int id, string DescricaoAtualizada)
        {
            Consultum ConsultaBuscada = BuscarPorId(id);

            if (DescricaoAtualizada != null && ConsultaBuscada != null)
            {
                ConsultaBuscada.Descricao = DescricaoAtualizada;

                ctx.Consulta.Update(ConsultaBuscada);

                ctx.SaveChanges();
            }
        }

        public Consultum BuscarPorId(int id)
        {
            return ctx.Consulta
                .Include("IdPacienteNavigation")
                .Include("IdMedicoNavigation")
                .Include("IdSituacaoNavigation")
                .FirstOrDefault(e => e.IdConsulta == id);
        }

        public void Cadastrar(Consultum NovaConsulta)
        {
            ctx.Consulta.Add(NovaConsulta);
            ctx.SaveChanges();
        }

        public List<Consultum> ListarMinhas(int id)
        {


            return ctx.Consulta
               .Select(c => new Consultum
               {
                   IdConsulta = c.IdConsulta,
                   DataConsulta = c.DataConsulta,
                   Descricao = c.Descricao,
                   IdPacienteNavigation = new Paciente
                   {
                       IdUsuario = c.IdPacienteNavigation.IdUsuario,
                       IdPaciente = c.IdPacienteNavigation.IdPaciente,
                       NomePaciente = c.IdPacienteNavigation.NomePaciente,
                       DataNasc = c.IdPacienteNavigation.DataNasc,
                       Telefone = c.IdPacienteNavigation.Telefone,
                       Rg = c.IdPacienteNavigation.Rg,
                       Cpf = c.IdPacienteNavigation.Cpf,
                   },
                   IdMedicoNavigation = new Medico
                   {
                       IdUsuario = c.IdMedicoNavigation.IdUsuario,
                       IdMedico = c.IdMedicoNavigation.IdMedico,
                       NomeMed = c.IdMedicoNavigation.NomeMed,
                       Crm = c.IdMedicoNavigation.Crm,
                       IdEspecialidadeNavigation = new Especialidade
                       {
                           IdEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.IdEspecialidade,
                           TituloEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.TituloEspecialidade
                       },
                       IdClinicaNavigation = new Clinica
                       {
                           IdClinica = c.IdMedicoNavigation.IdClinicaNavigation.IdClinica,
                           NomeFantasia = c.IdMedicoNavigation.IdClinicaNavigation.NomeFantasia,
                           IdEnderecoNavigation = new Endereco
                           {
                               IdEndereco = c.IdMedicoNavigation.IdClinicaNavigation.IdEnderecoNavigation.IdEndereco,
                               Rua = c.IdMedicoNavigation.IdClinicaNavigation.IdEnderecoNavigation.Rua,
                               Numero = c.IdMedicoNavigation.IdClinicaNavigation.IdEnderecoNavigation.Numero
                           },
                       },
                   },
                   IdSituacaoNavigation = new Situacao
                   {
                       IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                       Situacao1 = c.IdSituacaoNavigation.Situacao1
                   }
               })
                 .Where(c => c.IdMedicoNavigation.IdUsuario == id || c.IdPacienteNavigation.IdUsuario == id)
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
                 .Select(c => new Consultum()
                 {
                     IdConsulta = c.IdConsulta,
                     IdMedico = c.IdMedico,
                     IdSituacao = c.IdSituacao,
                     IdPaciente = c.IdPaciente,
                     DataConsulta = c.DataConsulta,
                     Descricao = c.Descricao,
                     IdPacienteNavigation = new Paciente
                     {
                         IdPaciente = c.IdPacienteNavigation.IdPaciente,
                         NomePaciente = c.IdPacienteNavigation.NomePaciente,
                         DataNasc = c.IdPacienteNavigation.DataNasc,
                         Telefone = c.IdPacienteNavigation.Telefone,
                         Rg = c.IdPacienteNavigation.Rg,
                         Cpf = c.IdPacienteNavigation.Cpf,
                     },
                     IdMedicoNavigation = new Medico
                     {
                         IdMedico = c.IdMedicoNavigation.IdMedico,
                         NomeMed = c.IdMedicoNavigation.NomeMed,
                         Crm = c.IdMedicoNavigation.Crm,
                         IdEspecialidadeNavigation = new Especialidade
                         {
                             IdEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.IdEspecialidade,
                             TituloEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.TituloEspecialidade
                         },

                         IdClinicaNavigation = new Clinica
                         {
                             IdClinica = c.IdMedicoNavigation.IdClinicaNavigation.IdClinica,
                             Cnpj = c.IdMedicoNavigation.IdClinicaNavigation.Cnpj,
                             NomeFantasia = c.IdMedicoNavigation.IdClinicaNavigation.NomeFantasia,
                             RazaoSocial = c.IdMedicoNavigation.IdClinicaNavigation.RazaoSocial
                         }
                     },
                     IdSituacaoNavigation = new Situacao
                     {
                         IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                         Situacao1 = c.IdSituacaoNavigation.Situacao1
                     }
                 })
                 .ToList();
        }

        public void Situacao(int id, string status)
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
