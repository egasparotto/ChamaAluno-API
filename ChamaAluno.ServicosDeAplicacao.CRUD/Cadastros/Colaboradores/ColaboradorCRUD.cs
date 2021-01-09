using AutoMapper;

using ChamaAluno.Dominio.Cadastros.Colaboradores.Entidades;
using ChamaAluno.Dominio.Cadastros.Colaboradores.Servicos;
using ChamaAluno.DTOs.Cadastros.Colaboradores;

using EGF.Dominio.UnidadesDeTrabalho;
using EGF.ServicosDeAplicacao.CRUD.Base;

namespace ChamaAluno.ServicosDeAplicacao.CRUD.Cadastros.Colaboradores
{
    public class ColaboradorCRUD : CRUD<Colaborador, IServicoDeColaborador, DTODeColaborador>, IColaboradorCRUD
    {
        public ColaboradorCRUD(IServicoDeColaborador servico, IUnidadeDeTrabalho unidadeDeTrabalho, IMapper mapeador) : base(servico, unidadeDeTrabalho, mapeador)
        {
        }
    }
}
