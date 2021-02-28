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
        public DTODeGridEGF<TDTO> ListarParaGrid(DTODeOpcoesDoGridEGF opcoes)
        {
            var skip = opcoes.NumeroDaPagina * opcoes.TotalNaPagina;
            var take = opcoes.TotalNaPagina;

            var retorno = new DTODeGridEGF<TDTO>();
            retorno.Dados = ServicoDeCrud.ListarParaGrid(opcoes.Pesquisa, skip, take).ToArray();

            var total = ServicoDeCrud.TotalParaGrid(opcoes.Pesquisa);

            retorno.Opcoes = new DTODeOpcoesDoGridEGF()
            {
                NumeroDaPagina = opcoes.NumeroDaPagina,
                Total = total,
                TotalNaPagina = opcoes.TotalNaPagina,
                TotalDePaginas = (int)Math.Ceiling(((double)total) / opcoes.TotalNaPagina)
            };
            return retorno;
        }
    }
}
