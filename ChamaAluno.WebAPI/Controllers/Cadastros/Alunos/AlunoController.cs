using ChamaAluno.DTOs.Cadastros.Alunos;
using ChamaAluno.ServicosDeAplicacao.CRUD.Cadastros.Alunos;
using ChamaAluno.WebAPI.Controllers.Base;

using Microsoft.AspNetCore.Mvc;

namespace ChamaAluno.WebAPI.Controllers.Cadastros.Alunos
{
    [ApiController]
    [Route("API/Cadastros/[controller]")]
    public class AlunoController : ControllerBase<DTODeAluno, IAlunoCRUD>
    {
        public AlunoController(IAlunoCRUD servicoDeCrud) : base(servicoDeCrud)
        {
        }
    }
}
