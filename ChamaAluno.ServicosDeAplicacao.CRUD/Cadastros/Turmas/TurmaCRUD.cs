using AutoMapper;

using ChamaAluno.Dominio.Cadastros.Turmas.Entidades;
using ChamaAluno.Dominio.Cadastros.Turmas.Servicos;
using ChamaAluno.DTOs.Cadastros.Turmas;
using ChamaAluno.ServicosDeAplicacao.CRUD.Base;

using EGF.Dominio.UnidadesDeTrabalho;

namespace ChamaAluno.ServicosDeAplicacao.CRUD.Cadastros.Turmas
{
    public class TurmaCRUD : ListagemCRUD<Turma, IServicoDeTurma, DTODeTurma>, ITurmaCRUD
    {
        public TurmaCRUD(IServicoDeTurma servico, IUnidadeDeTrabalho unidadeDeTrabalho, IMapper mapeador) : base(servico, unidadeDeTrabalho, mapeador)
        {
        }
    }
}
