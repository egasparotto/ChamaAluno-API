using AutoMapper;

using ChamaAluno.Dominio.Base.Utils;
using ChamaAluno.Dominio.Cadastros.Colaboradores.Entidades;
using ChamaAluno.Dominio.Cadastros.Pessoas.Entidades;
using ChamaAluno.DTOs.Cadastros.Colaboradores;
using ChamaAluno.DTOs.Cadastros.Pessoas;

using EGF.Dominio.Autenticacao.Perfis.Repositorios;
using EGF.DTOs.Mapeamentos.Base;

using System.Linq;

namespace ChamaAluno.DTOs.Mapeamentos.Cadastros.Colaboradores
{
    public class MapeadorDeDTODeColaborador : MapeadorDeDTO<Colaborador, DTODeColaborador>
    {
        private readonly IRepositorioDePerfil _repositorioDePerfil;

        public MapeadorDeDTODeColaborador(IRepositorioDePerfil repositorioDePerfil)
        {
           _repositorioDePerfil = repositorioDePerfil;
        }

        public override void DTOParaEntidade(IMappingExpression<DTODeColaborador, Colaborador> mapeamento)
        {
            mapeamento
                .IncludeBase<DTODePessoa, Pessoa>()
                .ForMember(x => x.Perfil, x => x.Ignore())
                .ForMember(x => x.Senha, x => x.Ignore())
                .AfterMap((dto, entidade) =>
                {
                    entidade.Perfil = _repositorioDePerfil.Buscar(x => x.Id == dto.IdDoPerfil).FirstOrDefault();
                    entidade.Senha = Criptografia.Criptografa(dto.Senha);
                });
        }

        public override void EntidadeParaDTO(IMappingExpression<Colaborador, DTODeColaborador> mapeamento)
        {
            mapeamento
                .IncludeBase<Pessoa, DTODePessoa>()
                .ForMember(x => x.Senha, x => x.Ignore())
                .ForMember(x => x.DescricaoDoPerfil, x => x.MapFrom(y => y.Perfil.Descricao));
        }
    }
}
