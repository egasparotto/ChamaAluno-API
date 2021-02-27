using ChamaAluno.DTOs.Base;
using ChamaAluno.DTOs.Framework.GridEGF;
using ChamaAluno.ServicosDeAplicacao.CRUD.Base;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;

namespace ChamaAluno.WebAPI.Controllers.Base
{
    public abstract class ControllerComLista<TDTO, TCRUD> : ControllerBase<TDTO, TCRUD>
        where TDTO : DTODoChamaAluno
        where TCRUD : IListagemCRUD<TDTO>
    {
        protected ControllerComLista(TCRUD servicoDeCrud) : base(servicoDeCrud)
        {
        }

        [HttpPost("ListarParaGrid")]
        public DTODeGridEGF<TDTO> ListarParaGrid(DTODePaginaDoGridEGF pagina, string pesquisa)
        {
            var skip = pagina.NumeroDaPagina * pagina.TotalNaPagina;
            var take = pagina.TotalNaPagina;

            var retorno = new DTODeGridEGF<TDTO>();
            retorno.Dados = ServicoDeCrud.ListarParaGrid(pesquisa, skip, take).ToArray();

            var total = ServicoDeCrud.TotalParaGrid(pesquisa);

            retorno.Pagina = new DTODePaginaDoGridEGF()
            {
                NumeroDaPagina = pagina.NumeroDaPagina,
                Total = total,
                TotalNaPagina = pagina.TotalNaPagina,
                TotalDePaginas = (int)Math.Ceiling(((double)total) / pagina.TotalNaPagina)
            };
            return retorno;
        }
    }
}
