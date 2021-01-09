using AutoMapper;

using ChamaAluno.Dominio.Cadastros.Turmas.Entidades;
using ChamaAluno.Dominio.Cadastros.Turmas.Servicos;
using ChamaAluno.DTOs.Cadastros.Turmas;

using EGF.Dominio.UnidadesDeTrabalho;
using EGF.ServicosDeAplicacao.CRUD.Base;

namespace ChamaAluno.ServicosDeAplicacao.CRUD.Cadastros.Turmas
{
    public class TurmaCRUD : CRUD<Turma, IServicoDeTurma, DTODeTurma>, ITurmaCRUD
    {
        public TurmaCRUD(IServicoDeTurma servico, IUnidadeDeTrabalho unidadeDeTrabalho, IMapper mapeador) : base(servico, unidadeDeTrabalho, mapeador)
        {
        }
    }
}
