using AutoMapper;

using ChamaAluno.Dominio.Cadastros.Alunos.Entidades;
using ChamaAluno.Dominio.Cadastros.Alunos.Servicos;
using ChamaAluno.DTOs.Cadastros.Alunos;

using EGF.Dominio.UnidadesDeTrabalho;
using EGF.ServicosDeAplicacao.CRUD.Base;

namespace ChamaAluno.ServicosDeAplicacao.CRUD.Cadastros.Alunos
{
    public class AlunoCRUD : CRUD<Aluno, IServicoDeAluno, DTODeAluno>, IAlunoCRUD
    {
        public AlunoCRUD(IServicoDeAluno servico, IUnidadeDeTrabalho unidadeDeTrabalho, IMapper mapeador) : base(servico, unidadeDeTrabalho, mapeador)
        {
        }
    }
}
