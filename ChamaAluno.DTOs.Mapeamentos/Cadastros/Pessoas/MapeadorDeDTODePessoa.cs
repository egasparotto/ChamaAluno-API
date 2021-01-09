using AutoMapper;

using ChamaAluno.Dominio.Cadastros.Pessoas.Entidades;
using ChamaAluno.DTOs.Cadastros.Pessoas;

using EGF.DTOs.Mapeamentos.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamaAluno.DTOs.Mapeamentos.Cadastros.Pessoas
{
    public class MapeadorDeDTODePessoa : MapeadorDeDTO<Pessoa, DTODePessoa>
    {
        public override void DTOParaEntidade(IMappingExpression<DTODePessoa, Pessoa> mapeamento)
        {
            mapeamento
                .ForMember(x => x.Foto, x => x.Ignore())
                .AfterMap((dto, entidade ) => {
                    entidade.AtualizaFoto(dto.Foto);
                }); ;
        }

        public override void EntidadeParaDTO(IMappingExpression<Pessoa, DTODePessoa> mapeamento)
        {
            mapeamento
                .ForMember(x => x.Foto, x => x.Ignore())
                .AfterMap((entidade, dto) => {
                    dto.Foto = entidade.FotoBase64();
                });
        }
    }
}
