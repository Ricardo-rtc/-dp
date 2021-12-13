using MongoDB.Driver;
using SP_Medical.webApi.Domains;
using SP_Medical.webApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SP_Medical.webApi.Repositories
{
    public class LocalizacaoRepository : IlocalizacaoRepository
    {
        private readonly IMongoCollection<Localizacao> _localizacoes;

        public LocalizacaoRepository()
        {
            var client = new MongoClient("mongodb://127.0.0.1:27017");
            var database = client.GetDatabase("spmedical");
            _localizacoes = database.GetCollection<Localizacao>("mapas");
        }

        public void Cadastrar(Localizacao novaLocalizacao)
        {
            _localizacoes.InsertOne(novaLocalizacao);

        }

        public List<Localizacao> ListarTodas()
        {
            return _localizacoes.Find(localizacao => true).ToList();
        }
    }
}
