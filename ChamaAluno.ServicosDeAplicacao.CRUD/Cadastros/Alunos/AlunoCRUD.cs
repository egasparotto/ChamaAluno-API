using AutoMapper;

using ChamaAluno.Dominio.Cadastros.Alunos.Entidades;
using ChamaAluno.Dominio.Cadastros.Alunos.Servicos;
using ChamaAluno.DTOs.Cadastros.Alunos;
using ChamaAluno.ServicosDeAplicacao.CRUD.Base;

using EGF.Dominio.UnidadesDeTrabalho;

namespace ChamaAluno.ServicosDeAplicacao.CRUD.Cadastros.Alunos
{
    public class AlunoCRUD : ChamaAlunoCRUD<Aluno, IServicoDeAluno, DTODeAluno>, IAlunoCRUD
    {
        public AlunoCRUD(IServicoDeAluno servico, IUnidadeDeTrabalho unidadeDeTrabalho, IMapper mapeador) : base(servico, unidadeDeTrabalho, mapeador)
        {
        }
    }
}
