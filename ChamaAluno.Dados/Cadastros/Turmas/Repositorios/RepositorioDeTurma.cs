using ChamaAluno.Dados.Base.Repositorios;
using ChamaAluno.Dominio.Cadastros.Turmas.Entidades;
using ChamaAluno.Dominio.Cadastros.Turmas.Repositorios;

using EGF.Dominio.UnidadesDeTrabalho;

namespace ChamaAluno.Dados.Cadastros.Turmas.Repositorios
{
    public class RepositorioDeTurma : RepositorioDoChamaAluno<Turma>, IRepositorioDeTurma
    {
        public RepositorioDeTurma(IUnidadeDeTrabalho unidadeDeTrabalho) : base(unidadeDeTrabalho)
        {

        }
    }
}
