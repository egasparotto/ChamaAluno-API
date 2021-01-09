using AutoMapper;

using ChamaAluno.Dominio.Cadastros.Pessoas.Entidades;
using ChamaAluno.Dominio.Cadastros.Responsaveis.Entidades;
using ChamaAluno.DTOs.Cadastros.Pessoas;
using ChamaAluno.DTOs.Cadastros.Responsaveis;

using EGF.DTOs.Mapeamentos.Base;

namespace ChamaAluno.DTOs.Mapeamentos.Cadastros.Responsaveis
{
    public class MapeadorDeDTODeResponsavel : MapeadorDeDTO<Responsavel, DTODeResponsavel>
    {
        public override void DTOParaEntidade(IMappingExpression<DTODeResponsavel, Responsavel> mapeamento)
        {
            mapeamento
                .IncludeBase<DTODePessoa, Pessoa>();
        }

        public override void EntidadeParaDTO(IMappingExpression<Responsavel, DTODeResponsavel> mapeamento)
        {
            mapeamento
                .IncludeBase<Pessoa, DTODePessoa>();
        }
    }
}
