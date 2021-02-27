using AutoMapper;

using ChamaAluno.Dominio.Cadastros.Responsaveis.Entidades;
using ChamaAluno.Dominio.Cadastros.Responsaveis.Servicos;
using ChamaAluno.DTOs.Cadastros.Responsaveis;
using ChamaAluno.ServicosDeAplicacao.CRUD.Base;

using EGF.Dominio.UnidadesDeTrabalho;

namespace ChamaAluno.ServicosDeAplicacao.CRUD.Cadastros.Responsaveis
{
    public class ResponsavelCRUD : ListagemCRUD<Responsavel, IServicoDeResponsavel, DTODeResponsavel>, IResponsavelCRUD
    {
        public ResponsavelCRUD(IServicoDeResponsavel servico, IUnidadeDeTrabalho unidadeDeTrabalho, IMapper mapeador) : base(servico, unidadeDeTrabalho, mapeador)
        {
        }
    }
}
