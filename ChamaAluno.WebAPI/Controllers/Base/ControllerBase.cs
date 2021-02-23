using ChamaAluno.DTOs.Base;
using ChamaAluno.DTOs.Framework.Exibicoes;
using ChamaAluno.ServicosDeAplicacao.CRUD.Base;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;

namespace ChamaAluno.WebAPI.Controllers.Base
{
    [ApiController]
    public abstract class ControllerBase<TDTO, TCRUD> : ControllerBase
        where TDTO : DTODoChamaAluno
        where TCRUD : IChamaAlunoCRUD<TDTO>
    {
        protected TCRUD ServicoDeCrud { get; }
        public ControllerBase(TCRUD servicoDeCrud)
        {
            ServicoDeCrud = servicoDeCrud;
        }

        [HttpGet]
        public IEnumerable<TDTO> ObterTodos()
        {
            return ServicoDeCrud.ObterTodos();
        }

        [HttpGet("{id}")]
        public TDTO ObterPorId(int id)
        {
            return ServicoDeCrud.ObterPorId(id);
        }

        [HttpPost]
        public TDTO Inserir(TDTO dto)
        {
            return ServicoDeCrud.Inserir(dto);
        }

        [HttpPut]
        public TDTO Editar(TDTO dto)
        {
            return ServicoDeCrud.Editar(dto);
        }

        [HttpDelete]
        public void Remover(TDTO dto)
        {
            ServicoDeCrud.Remover(dto);
        }

        [HttpGet("Exibicoes")]
        public virtual IList<DTODeExibicao> ObterExibicoes()
        {
            throw new NotImplementedException();
        }
    }
}
