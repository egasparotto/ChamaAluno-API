using ChamaAluno.DTOs.Cadastros.Colaboradores;
using ChamaAluno.ServicosDeAplicacao.CRUD.Cadastros.Colaboradores;
using ChamaAluno.WebAPI.Controllers.Base;

using Microsoft.AspNetCore.Mvc;

namespace ChamaAluno.WebAPI.Controllers.Cadastros.Colaboradores
{
    [ApiController]
    [Route("API/Cadastros/[controller]")]
    public class ColaboradorController : ControllerBase<DTODeColaborador, IColaboradorCRUD>
    {
        public ColaboradorController(IColaboradorCRUD servicoDeCrud) : base(servicoDeCrud)
        {
        }
    }
}
