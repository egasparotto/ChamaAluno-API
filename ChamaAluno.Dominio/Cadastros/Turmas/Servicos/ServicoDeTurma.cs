using ChamaAluno.Dominio.Base.Servicos;
using ChamaAluno.Dominio.Cadastros.Turmas.Entidades;
using ChamaAluno.Dominio.Cadastros.Turmas.Repositorios;

namespace ChamaAluno.Dominio.Cadastros.Turmas.Servicos
{
    public class ServicoDeTurma : ServicoComListagem<Turma, IRepositorioDeTurma>, IServicoDeTurma
    {
        public ServicoDeTurma(IRepositorioDeTurma repositorio) : base(repositorio)
        {
        }
    }
}
