using ChamaAluno.Dominio.Cadastros.Alunos.Entidades;
using ChamaAluno.Dominio.Cadastros.Alunos.Repositorios;
using ChamaAluno.Dominio.Cadastros.Pessoas.Servicos;

using EGF.Dominio.Contextos;

namespace ChamaAluno.Dominio.Cadastros.Alunos.Servicos
{
    public class ServicoDeAluno : ServicoDePessoa<Aluno, IRepositorioDeAluno>, IServicoDeAluno
    {
        public ServicoDeAluno(IRepositorioDeAluno repositorio, IContexto contextoDaAplicacao) : base(repositorio, contextoDaAplicacao)
        {
        }
    }
}
