using System;
using System.Collections.Generic;

#nullable disable

namespace SP_Medical.webApi.Domains
{
    public partial class Cliente
    {
        public Cliente()
        {
            Alugueis = new HashSet<Aluguei>();
        }

        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }

        public virtual ICollection<Aluguei> Alugueis { get; set; }
    }
}
