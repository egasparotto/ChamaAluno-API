
using ChamaAluno.Dados.Base.Repositorios;
using ChamaAluno.Dominio.Cadastros.Alunos.Entidades;
using ChamaAluno.Dominio.Cadastros.Alunos.Repositorios;

using EGF.Dominio.UnidadesDeTrabalho;

using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChamaAluno.Dados.Cadastros.Alunos.Repositorios
{
    public class RepositorioDeAluno : RepositorioDoChamaAluno<Aluno>, IRepositorioDeAluno
    {
        protected IRepositorioDeAlunoDoResponsavel RepositorioDeAlunoDoResponsavel { get; set; }

        public RepositorioDeAluno(IUnidadeDeTrabalho unidadeDeTrabalho, IRepositorioDeAlunoDoResponsavel repositorioDeAlunoDoResponsavel) : base(unidadeDeTrabalho)
        {
            RepositorioDeAlunoDoResponsavel = repositorioDeAlunoDoResponsavel;
        }

        public override IQueryable<Aluno> Buscar()
        {
            return base.Buscar()
                .Include(x => x.Turma)
                .Include(x => x.AlunosResponsaveis)
                    .ThenInclude(x => x.Responsavel);
        }

        public override Aluno Editar(Aluno entidade)
        {
            return base.Editar(entidade);
        }

        public override async Task<Aluno> EditarAsync(Aluno entidade)
        {
            var idDosResponsaveisAtuais = entidade.AlunosResponsaveis.Select(x => x.Id);
            var responsaveisExcluidos = RepositorioDeAlunoDoResponsavel.Buscar(x => x.IdDoAluno == entidade.Id && !idDosResponsaveisAtuais.Contains(x.Id));
            await RepositorioDeAlunoDoResponsavel.RemoverAsync(responsaveisExcluidos);
            foreach (var responsavelDoAluno in entidade.AlunosResponsaveis)
            {
                responsavelDoAluno.Responsavel = null;
                responsavelDoAluno.Aluno = null;
            }
            return await base.EditarAsync(entidade);
        }

        public override Aluno Inserir(Aluno entidade)
        {
            foreach (var responsavelDoAluno in entidade.AlunosResponsaveis)
            {
                responsavelDoAluno.Responsavel = null;
                responsavelDoAluno.Aluno = null;
            }
            return base.Inserir(entidade);
        }

        public override Task<Aluno> InserirAsync(Aluno entidade)
        {
            foreach (var responsavelDoAluno in entidade.AlunosResponsaveis)
            {
                responsavelDoAluno.Responsavel = null;
                responsavelDoAluno.Aluno = null;
            }
            return base.InserirAsync(entidade);
        }
    }
}
