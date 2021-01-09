using ChamaAluno.Dominio.Base.Servicos;
using ChamaAluno.Dominio.Cadastros.Pessoas.Entidades;

using EGF.Dominio.Contextos;
using EGF.Dominio.Repositorios;

namespace ChamaAluno.Dominio.Cadastros.Pessoas.Servicos
{
    public class ServicoDePessoa<TEntidade, TRepositorio> : ServicoComListagem<TEntidade, TRepositorio>
        where TEntidade : Pessoa
        where TRepositorio : IRepositorioComId<TEntidade>
    {
        protected IContexto ContextoDaAplicacao { get; set; }

        public ServicoDePessoa(TRepositorio repositorio, IContexto contextoDaAplicacao) : base(repositorio)
        {
            ContextoDaAplicacao = contextoDaAplicacao;
        }
    }
}
