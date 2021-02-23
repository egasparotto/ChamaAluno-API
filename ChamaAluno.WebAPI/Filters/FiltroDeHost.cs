﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using System.Linq;

namespace ChamaAluno.WebAPI.Filters
{
    public class FiltroDeHost : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Claims.Any())
            {
                var claim = context.HttpContext.User.Claims.First(c => c.Type == "host");
                var hostJWT = claim.Value;
                var host = context.HttpContext.Request.Host.Host;

                if (hostJWT != host)
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 401
                    };
                }
            }
        }
    }
}
