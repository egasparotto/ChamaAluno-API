using ChamaAluno.DTOs.Cadastros.Responsaveis;
using ChamaAluno.ServicosDeAplicacao.CRUD.Cadastros.Responsaveis;
using ChamaAluno.WebAPI.Controllers.Base;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamaAluno.WebAPI.Controllers.Cadastros.Responsaveis
{
    [ApiController]
    [Route("API/Cadastros/[controller]")]
    public class ResponsavelController : ControllerBase<DTODeResponsavel, IResponsavelCRUD>
    {
        public ResponsavelController(IResponsavelCRUD servicoDeCrud) : base(servicoDeCrud)
        {
        }
    }
}
