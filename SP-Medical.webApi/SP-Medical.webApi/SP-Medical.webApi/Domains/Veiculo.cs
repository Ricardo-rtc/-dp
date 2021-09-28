using System;
using System.Collections.Generic;

#nullable disable

namespace SP_Medical.webApi.Domains
{
    public partial class Veiculo
    {
        public Veiculo()
        {
            Alugueis = new HashSet<Aluguei>();
        }

        public int IdVeiculo { get; set; }
        public int? IdModelo { get; set; }
        public string Placa { get; set; }
        public int? IdEmpresa { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Modelo IdModeloNavigation { get; set; }
        public virtual ICollection<Aluguei> Alugueis { get; set; }
    }
}
