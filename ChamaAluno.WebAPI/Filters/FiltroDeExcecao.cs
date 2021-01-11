using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChamaAluno.WebAPI.Filters
{
    public class FiltroDeExcecao : ExceptionFilterAttribute
    {
        public FiltroDeExcecao()
        {
        }

        public override void OnException(ExceptionContext context)
        {
            var erros = new Dictionary<string, string[]>()
            {
                { "", new string[] { context.Exception.Message } }
            };

            var resposta = new ValidationProblemDetails(erros) 
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = "One or more validation errors occurred.",
                Status = 500
            };

            context.Result = new ContentResult()
            {
                Content = JsonSerializer.Serialize(resposta),
                StatusCode = 500,
                ContentType = "application/problem+json"
            };

        }
    }
}
