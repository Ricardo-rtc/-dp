using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SP_Medical.webApi.Domains
{
    public partial class Consultum
    {
        public int IdConsulta { get; set; }
        [Required(ErrorMessage = "O campo Medico é obrigatório!")]
        public int? IdMedico { get; set; }
        public int? IdSituacao { get; set; }
        public int? IdPaciente { get; set; }
        public DateTime? DataConsulta { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao IdSituacaoNavigation { get; set; }
    }
}
