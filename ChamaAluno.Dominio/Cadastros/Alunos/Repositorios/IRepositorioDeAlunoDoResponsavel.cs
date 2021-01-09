using ChamaAluno.Dominio.Cadastros.Alunos.Entidades;

using EGF.Dominio.Repositorios;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChamaAluno.Dominio.Cadastros.Alunos.Repositorios
{
    public interface IRepositorioDeAlunoDoResponsavel : IRepositorio<AlunoDoResponsavel>
    {
        IEnumerable<AlunoDoResponsavel> ObterAlunosAutorizados(int idDoResponsavel, DateTime data);
        void Remover(IEnumerable<AlunoDoResponsavel> responsaveisExcluidos);
        Task RemoverAsync(IEnumerable<AlunoDoResponsavel> responsaveisExcluidos);
    }
}
