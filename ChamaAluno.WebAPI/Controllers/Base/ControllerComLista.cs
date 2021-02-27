using ChamaAluno.DTOs.Base;
using ChamaAluno.ServicosDeAplicacao.CRUD.Base;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

namespace ChamaAluno.WebAPI.Controllers.Base
{
    public abstract class ControllerComLista<TDTO, TCRUD> : ControllerBase<TDTO, TCRUD>
        where TDTO : DTODoChamaAluno
        where TCRUD : IListagemCRUD<TDTO>
    {
        protected ControllerComLista(TCRUD servicoDeCrud) : base(servicoDeCrud)
        {
        }

        [HttpGet("ListarParaGrid")]
        public IEnumerable<TDTO> ListarParaGrid(string pesquisa)
        {
            return ServicoDeCrud.ListarParaGrid(pesquisa);
        }
    }
}
