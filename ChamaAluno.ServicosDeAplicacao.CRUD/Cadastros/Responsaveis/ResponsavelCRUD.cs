using AutoMapper;

using ChamaAluno.Dominio.Cadastros.Responsaveis.Entidades;
using ChamaAluno.Dominio.Cadastros.Responsaveis.Servicos;
using ChamaAluno.DTOs.Cadastros.Responsaveis;

using EGF.Dominio.UnidadesDeTrabalho;
using EGF.ServicosDeAplicacao.CRUD.Base;

namespace ChamaAluno.ServicosDeAplicacao.CRUD.Cadastros.Responsaveis
{
    public class ResponsavelCRUD : CRUD<Responsavel, IServicoDeResponsavel, DTODeResponsavel>, IResponsavelCRUD
    {
        public ResponsavelCRUD(IServicoDeResponsavel servico, IUnidadeDeTrabalho unidadeDeTrabalho, IMapper mapeador) : base(servico, unidadeDeTrabalho, mapeador)
        {
        }
    }
}
