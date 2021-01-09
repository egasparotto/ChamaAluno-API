using ChamaAluno.Dominio.Cadastros.Responsaveis.Entidades;
using ChamaAluno.Dominio.Cadastros.Responsaveis.Repositorios;

using EGF.Dados.EFCore.Repositorios;
using EGF.Dominio.UnidadesDeTrabalho;

namespace ChamaAluno.Dados.Cadastros.Responsaveis.Repositorios
{
    public class RepositorioDeResponsavel : RepositorioComId<Responsavel>, IRepositorioDeResponsavel
    {
        public RepositorioDeResponsavel(IUnidadeDeTrabalho contextoDaAplicacao) : base(contextoDaAplicacao)
        {

        }
    }
}
