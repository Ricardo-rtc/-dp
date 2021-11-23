using SP_Medical.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical.webApi.Interfaces
{
    interface IMedicoRepository
    {
        /// <summary>
        /// Método responsavel por listar todos os médicos
        /// </summary>
        /// <returns>Uma lista de médicos</returns>
        List<Medico> Listar();

        /// <summary>
        /// Método responsavel por buscar um médico por um id especifico
        /// </summary>
        /// <param name="id">Id do médico a ser buscado</param>
        /// <returns>Medico encontrado</returns>
        Medico Buscar(int id);

        /// <summary>
        /// Método responsavel por cadastrar um novo médico
        /// </summary>
        /// <param name="mediconovo">Objeto do tipo Médico a ser cadastrado</param>
        void Cadastrar(Medico mediconovo);

        /// <summary>
        /// Método responsavel pela atualização de algum cadastro de médico
        /// </summary>
        /// <param name="medicoatualizado">Dados Atualizados</param>
        /// <param name="id">Id do médico a ser atualizado</param>
        void Atualizar(Medico medicoatualizado, int id);

        /// <summary>
        /// Método responsavel por deletar um médico
        /// </summary>
        /// <param name="id">Id do médico a ser deletado</param>
        void Deletar(int id);
    }
}
