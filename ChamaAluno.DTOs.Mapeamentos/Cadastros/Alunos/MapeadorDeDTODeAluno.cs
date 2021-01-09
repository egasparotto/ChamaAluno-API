using AutoMapper;

using ChamaAluno.Dominio.Cadastros.Alunos.Entidades;
using ChamaAluno.Dominio.Cadastros.Pessoas.Entidades;
using ChamaAluno.Dominio.Cadastros.Turmas.Repositorios;
using ChamaAluno.DTOs.Cadastros.Alunos;
using ChamaAluno.DTOs.Cadastros.Pessoas;

using EGF.DTOs.Mapeamentos.Base;

using System.Linq;

namespace ChamaAluno.DTOs.Mapeamentos.Cadastros.Alunos
{
    public class MapeadorDeDTODeAluno : MapeadorDeDTO<Aluno, DTODeAluno>
    {
        private readonly IRepositorioDeTurma _repositorioDeTurma;

        public MapeadorDeDTODeAluno(IRepositorioDeTurma repositorioDeTurma)
        {
            _repositorioDeTurma = repositorioDeTurma;
        }

        public override void DTOParaEntidade(IMappingExpression<DTODeAluno, Aluno> mapeamento)
        {
            mapeamento
                .IncludeBase<DTODePessoa, Pessoa>()
                .ForMember(x => x.Turma, x => x.Ignore())
                .AfterMap((dto, entidade) =>
                {
                    entidade.Turma = _repositorioDeTurma.Buscar(x => x.Id == dto.IdDaTurma).FirstOrDefault();
                });
        }

        public override void EntidadeParaDTO(IMappingExpression<Aluno, DTODeAluno> mapeamento)
        {
            mapeamento
                .IncludeBase<Pessoa, DTODePessoa>()
                .ForMember(x => x.DescricaoDaTurma, x => x.MapFrom(y => y.Turma.Descricao));
        }
    }
}
