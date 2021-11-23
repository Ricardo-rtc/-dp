using System;
using System.Collections.Generic;

#nullable disable

namespace SP_Medical.webApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdPaciente { get; set; }
        public int? IdEndereco { get; set; }
        public int? IdUsuario { get; set; }
        public string NomePaciente { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataNasc { get; set; }
        public string Telefone { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
