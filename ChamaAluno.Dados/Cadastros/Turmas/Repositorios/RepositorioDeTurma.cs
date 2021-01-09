using ChamaAluno.Dominio.Cadastros.Turmas.Entidades;
using ChamaAluno.Dominio.Cadastros.Turmas.Repositorios;

using EGF.Dados.EFCore.Repositorios;
using EGF.Dominio.UnidadesDeTrabalho;

namespace ChamaAluno.Dados.Cadastros.Turmas.Repositorios
{
    public class RepositorioDeTurma : RepositorioComId<Turma>, IRepositorioDeTurma
    {
        public RepositorioDeTurma(IUnidadeDeTrabalho unidadeDeTrabalho) : base(unidadeDeTrabalho)
        {

        }
    }
}
