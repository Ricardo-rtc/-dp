using System;
using System.Collections.Generic;

#nullable disable

namespace SP_Medical.webApi.Domains
{
    public partial class Modelo
    {
        public Modelo()
        {
            Veiculos = new HashSet<Veiculo>();
        }

        public int IdModelo { get; set; }
        public string Descricao { get; set; }
        public int? IdMarca { get; set; }

        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual ICollection<Veiculo> Veiculos { get; set; }
    }
}
