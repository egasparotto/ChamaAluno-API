using ChamaAluno.WebAPI.Controllers.Administracao.Licencas;

using EGF.Dominio.UnidadesDeTrabalho;

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace ChamaAluno.WebAPI.Filters
{
    public class FiltroDeAtualizacaoDoBanco : IActionFilter
    {

        public FiltroDeAtualizacaoDoBanco()
        {

        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            if (context.Controller.GetType() != typeof(LicenciamentoController))
            {
                var unidadeDeTrabalho = (IUnidadeDeTrabalho)context.HttpContext.RequestServices.GetService(typeof(IUnidadeDeTrabalho));
                unidadeDeTrabalho.Contexto.Database.Migrate();
            }
        }
    }
}
