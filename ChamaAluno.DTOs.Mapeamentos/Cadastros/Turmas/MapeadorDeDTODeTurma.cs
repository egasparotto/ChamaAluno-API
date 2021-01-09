using AutoMapper;

using ChamaAluno.Dominio.Cadastros.Turmas.Entidades;
using ChamaAluno.DTOs.Cadastros.Turmas;

using EGF.DTOs.Mapeamentos.Base;

namespace ChamaAluno.DTOs.Mapeamentos.Cadastros.Turmas
{
    public class MapeadorDeDTODeTurma : MapeadorDeDTO<Turma, DTODeTurma>
    {
        public override void DTOParaEntidade(IMappingExpression<DTODeTurma, Turma> mapeamento)
        {

        }

        public override void EntidadeParaDTO(IMappingExpression<Turma, DTODeTurma> mapeamento)
        {

        }
    }
}
