using AutoMapper;

using ChamaAluno.Dominio.Base.Entidades;
using ChamaAluno.Dominio.Base.Interfaces;
using ChamaAluno.DTOs.Base;

using EGF.Dominio.UnidadesDeTrabalho;

using System.Collections.Generic;
using System.Linq;

namespace ChamaAluno.ServicosDeAplicacao.CRUD.Base
{
    public class ListagemCRUD<TEntidade, TServico, TDTO> : ChamaAlunoCRUD<TEntidade, TServico, TDTO>, IListagemCRUD<TDTO>
        where TEntidade : EntidadeDoChamaAluno
        where TServico : IServicoComListagem<TEntidade>
        where TDTO : DTODoChamaAluno
    {
        public ListagemCRUD(TServico servico, IUnidadeDeTrabalho unidadeDeTrabalho, IMapper mapeador) : base(servico, unidadeDeTrabalho, mapeador)
        {
        }

        public IEnumerable<TDTO> ListarParaGrid(string pesquisa)
        {
            return Mapeador.Map<IEnumerable<TDTO>>(Servico.Buscar(pesquisa));
        }
    }
}
