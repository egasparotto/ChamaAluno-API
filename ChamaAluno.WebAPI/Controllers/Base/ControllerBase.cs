using ChamaAluno.DTOs.Framework.Exibicoes;

using EGF.Dominio.UnidadesDeTrabalho;
using EGF.DTOs.Entidades;
using EGF.ServicosDeAplicacao.CRUD.Base;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;

namespace ChamaAluno.WebAPI.Controllers.Base
{
    [ApiController]
    public abstract class ControllerBase<TDTO, TCRUD> : ControllerBase
        where TDTO : DTODeEntidade
        where TCRUD : ICRUD<TDTO>
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
