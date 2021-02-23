using AutoMapper;

using ChamaAluno.Dominio.Cadastros.Colaboradores.Entidades;
using ChamaAluno.Dominio.Cadastros.Colaboradores.Servicos;
using ChamaAluno.DTOs.Cadastros.Colaboradores;
using ChamaAluno.ServicosDeAplicacao.CRUD.Base;

using EGF.Dominio.UnidadesDeTrabalho;

namespace ChamaAluno.ServicosDeAplicacao.CRUD.Cadastros.Colaboradores
{
    public class ColaboradorCRUD : ChamaAlunoCRUD<Colaborador, IServicoDeColaborador, DTODeColaborador>, IColaboradorCRUD
    {
        public ColaboradorCRUD(IServicoDeColaborador servico, IUnidadeDeTrabalho unidadeDeTrabalho, IMapper mapeador) : base(servico, unidadeDeTrabalho, mapeador)
        {
        }
    }
}
