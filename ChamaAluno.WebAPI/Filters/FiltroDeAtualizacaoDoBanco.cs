﻿using ChamaAluno.Dados.Contexto;

using EGF.Dados.EFCore.Fabricas;
using EGF.Dados.EFCore.UnidadesDeTrabalho;
using EGF.Dominio.UnidadesDeTrabalho;
using EGF.Licenciamento.WEB.Gerenciadores;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            try
            {
                var unidadeDeTrabalho = (IUnidadeDeTrabalho)context.HttpContext.RequestServices.GetService(typeof(IUnidadeDeTrabalho));
                unidadeDeTrabalho.Contexto.Database.Migrate();
            }
            catch(Exception e)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 500,
                    Content = e.Message + '\n' + e.StackTrace
                };
            }
        }
    }
}
