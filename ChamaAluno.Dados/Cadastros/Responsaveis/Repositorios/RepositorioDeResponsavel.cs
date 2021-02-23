using ChamaAluno.Dados.Base.Repositorios;
using ChamaAluno.Dominio.Cadastros.Responsaveis.Entidades;
using ChamaAluno.Dominio.Cadastros.Responsaveis.Repositorios;

using EGF.Dominio.UnidadesDeTrabalho;

namespace ChamaAluno.Dados.Cadastros.Responsaveis.Repositorios
{
    public class RepositorioDeResponsavel : RepositorioDoChamaAluno<Responsavel>, IRepositorioDeResponsavel
    {
        public RepositorioDeResponsavel(IUnidadeDeTrabalho contextoDaAplicacao) : base(contextoDaAplicacao)
        {

        }
    }
}
