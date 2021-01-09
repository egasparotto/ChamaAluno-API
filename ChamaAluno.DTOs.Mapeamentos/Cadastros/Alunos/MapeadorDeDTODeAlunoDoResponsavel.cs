using AutoMapper;

using ChamaAluno.Dominio.Cadastros.Alunos.Entidades;
using ChamaAluno.Dominio.Cadastros.Responsaveis.Repositorios;
using ChamaAluno.DTOs.Cadastros.Alunos;

using EGF.DTOs.Mapeamentos.Base;

using System.Linq;

namespace ChamaAluno.DTOs.Mapeamentos.Cadastros.Alunos
{
    public class MapeadorDeDTODeAlunoDoResponsavel : MapeadorDeDTO<AlunoDoResponsavel, DTODeAlunoDoResponsavel>
    {
        private readonly IRepositorioDeResponsavel _repositorioDeResponsavel;

        public MapeadorDeDTODeAlunoDoResponsavel(IRepositorioDeResponsavel repositorioDeResponsavel)
        {
            _repositorioDeResponsavel = repositorioDeResponsavel;
        }

        public override void DTOParaEntidade(IMappingExpression<DTODeAlunoDoResponsavel, AlunoDoResponsavel> mapeamento)
        {
            mapeamento
                .ForMember(x => x.Responsavel, x => x.Ignore())
                .AfterMap((dto, entidade) =>
                {
                    entidade.Responsavel = _repositorioDeResponsavel.Buscar(x => x.Id == dto.IdDoResponsavel).FirstOrDefault();
                });
        }

        public override void EntidadeParaDTO(IMappingExpression<AlunoDoResponsavel, DTODeAlunoDoResponsavel> mapeamento)
        {
            mapeamento
                .ForMember(x => x.NomeDoResponsavel, x => x.MapFrom(y => y.Responsavel.Nome));
        }
    }
}
