using ChamaAluno.DTOs.Cadastros.Pessoas;
using ChamaAluno.WebAPI.Controllers.Base;

using EGF.ServicosDeAplicacao.CRUD.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamaAluno.WebAPI.Controllers.Cadastros.Pessoas
{
    public abstract class ControllerDePessoa<TDTO, TCRUD> : ControllerBase<TDTO, TCRUD>
        where TDTO: DTODePessoa
        where TCRUD: ICRUD<TDTO>
    {
        protected ControllerDePessoa(TCRUD servicoDeCrud) : base(servicoDeCrud)
        {
        }
    }
}
