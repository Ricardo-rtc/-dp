using SP_Medical.webApi.Domains;
using System.Collections.Generic;

namespace SP_Medical.webApi.Interfaces
{
    interface IlocalizacaoRepository
    {
        List<Localizacao> ListarTodas();

        void Cadastrar(Localizacao novaLocalizacao);
    }
}
