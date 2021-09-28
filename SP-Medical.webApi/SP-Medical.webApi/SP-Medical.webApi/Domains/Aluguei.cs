using System;
using System.Collections.Generic;

#nullable disable

namespace SP_Medical.webApi.Domains
{
    public partial class Aluguei
    {
        public int IdAluguel { get; set; }
        public int? IdCliente { get; set; }
        public int? IdVeiculo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Veiculo IdVeiculoNavigation { get; set; }
    }
}
