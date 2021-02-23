
using AutoMapper;

using ChamaAluno.Dominio.Base.Entidades;
using ChamaAluno.Dominio.Base.Interfaces;
using ChamaAluno.DTOs.Base;

using EGF.Dominio.UnidadesDeTrabalho;
using EGF.ServicosDeAplicacao.CRUD.Base;

namespace ChamaAluno.ServicosDeAplicacao.CRUD.Base
{
    public class ChamaAlunoCRUD<TEntidade, TServico, TDTO> : CRUD<int, TEntidade, TServico, TDTO>
        where TEntidade : EntidadeDoChamaAluno
        where TServico : IServicoDePersistenciaDoChamaAluno<TEntidade>
        where TDTO : DTODoChamaAluno
    {
        public ChamaAlunoCRUD(TServico servico, IUnidadeDeTrabalho unidadeDeTrabalho, IMapper mapeador) : base(servico, unidadeDeTrabalho, mapeador)
        {
        }
    }
}
