using ChamaAluno.DTOs.Cadastros.Responsaveis;
using ChamaAluno.ServicosDeAplicacao.CRUD.Cadastros.Responsaveis;
using ChamaAluno.WebAPI.Controllers.Base;

using Microsoft.AspNetCore.Mvc;

namespace ChamaAluno.WebAPI.Controllers.Cadastros.Responsaveis
{
    [ApiController]
    [Route("API/Cadastros/[controller]")]
    public class ResponsavelController : ControllerComLista<DTODeResponsavel, IResponsavelCRUD>
    {
        public ResponsavelController(IResponsavelCRUD servicoDeCrud) : base(servicoDeCrud)
        {
        }
    }
}
