using ChamaAluno.DTOs.Cadastros.Pessoas;
using ChamaAluno.ServicosDeAplicacao.CRUD.Base;
using ChamaAluno.WebAPI.Controllers.Base;

namespace ChamaAluno.WebAPI.Controllers.Cadastros.Pessoas
{
    public abstract class ControllerDePessoa<TDTO, TCRUD> : ControllerBase<TDTO, TCRUD>
        where TDTO : DTODePessoa
        where TCRUD : IChamaAlunoCRUD<TDTO>
    {
        protected ControllerDePessoa(TCRUD servicoDeCrud) : base(servicoDeCrud)
        {
        }
    }
}
