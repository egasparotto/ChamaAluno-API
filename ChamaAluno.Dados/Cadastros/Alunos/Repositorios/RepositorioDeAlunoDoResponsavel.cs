using ChamaAluno.Dominio.Cadastros.Alunos.Entidades;
using ChamaAluno.Dominio.Cadastros.Alunos.Repositorios;

using EGF.Dados.EFCore.Repositorios;
using EGF.Dominio.UnidadesDeTrabalho;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamaAluno.Dados.Cadastros.Alunos.Repositorios
{
    public class RepositorioDeAlunoDoResponsavel : Repositorio<AlunoDoResponsavel>, IRepositorioDeAlunoDoResponsavel
    {
        public RepositorioDeAlunoDoResponsavel(IUnidadeDeTrabalho unidadeDeTrabalho) : base(unidadeDeTrabalho)
        {

        }
        public override IQueryable<AlunoDoResponsavel> Buscar()
        {
            return base.Buscar()
                .Include(x => x.Aluno)
                    .ThenInclude(x => x.Turma)
                .Include(x => x.Responsavel);
        }

        public IEnumerable<AlunoDoResponsavel> ObterAlunosAutorizados(int idDoResponsavel, DateTime data)
        {
            return UnidadeDeTrabalho.Contexto.Set<AlunoDoResponsavel>()
                .Include(x => x.Aluno)
                    .ThenInclude(x => x.Turma)
                .Include(x => x.Responsavel)
                .Where(x => x.IdDoResponsavel == idDoResponsavel && data >= x.InicioDaValidade.Date && (x.TerminoDaValidade == null || data <= x.TerminoDaValidade.Value.Date)).ToList();
        }

        public void Remover(IEnumerable<AlunoDoResponsavel> responsaveisExcluidos)
        {
            foreach (var item in responsaveisExcluidos)
            {
                Remover(item);
            }
        }

        public async Task RemoverAsync(IEnumerable<AlunoDoResponsavel> responsaveisExcluidos)
        {
            foreach (var item in responsaveisExcluidos)
            {
                await RemoverAsync(item);
            }
        }
    }
}
