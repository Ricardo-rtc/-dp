using System;
using System.Collections.Generic;

#nullable disable

namespace SP_Medical.webApi.Domains
{
    public partial class Empresa
    {
        public Empresa()
        {
            Veiculos = new HashSet<Veiculo>();
        }

        public int IdEmpresa { get; set; }
        public string NomeEmpresa { get; set; }

        public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
}
