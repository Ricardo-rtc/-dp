using SP_Medical.webApi.Contexts;
using SP_Medical.webApi.Domains;
using SP_Medical.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical.webApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository 
    {
        SpMedicalContext ctx = new SpMedicalContext();
        public void Atualizar(int idClinica, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = BuscarPorId(idClinica);

            if (clinicaAtualizada.IdEndereco != null && clinicaAtualizada.NomeFantasia != null && clinicaAtualizada.Cnpj != null && clinicaAtualizada.RazaoSocial != null)
            {
                clinicaBuscada.IdEndereco = clinicaAtualizada.IdEndereco;
                clinicaBuscada.NomeFantasia = clinicaAtualizada.NomeFantasia;
                clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;
                clinicaBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;
            }

            ctx.Clinicas.Update(clinicaBuscada);

            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int idClinica)
        {
            return ctx.Clinicas.FirstOrDefault(c => c.IdClinica == idClinica);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int idClinica)
        {
            Clinica clinicaBuscada = BuscarPorId(idClinica);

            ctx.Clinicas.Remove(clinicaBuscada);

            ctx.SaveChanges();
        }

        public List<Clinica> ListarTodos()
        {
            return ctx.Clinicas
                .Select(c => new Clinica
                {
                    IdClinica = c.IdClinica,
                    IdEnderecoNavigation = new Endereco
                    {
                        Rua = c.IdEnderecoNavigation.Rua,
                        Numero = c.IdEnderecoNavigation.Numero,
                        Cidade = c.IdEnderecoNavigation.Cidade,
                        Estado = c.IdEnderecoNavigation.Estado,
                        Cep = c.IdEnderecoNavigation.Cep
                    },
                    NomeFantasia = c.NomeFantasia,
                    Cnpj = c.Cnpj,
                    RazaoSocial = c.RazaoSocial,
                    Medicos = c.Medicos
                }).ToList();
        }
    }
}
