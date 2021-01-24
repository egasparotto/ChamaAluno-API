﻿using ChamaAluno.DTOs.Cadastros.Turmas;
using ChamaAluno.DTOs.Framework.Exibicoes;
using ChamaAluno.ServicosDeAplicacao.CRUD.Cadastros.Turmas;
using ChamaAluno.WebAPI.Controllers.Base;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChamaAluno.WebAPI.Controllers.Cadastros.Turmas
{
    [ApiController]
    [Route("Cadastros/[controller]")]
    public class TurmaController : ControllerBase<DTODeTurma, ITurmaCRUD>
    {
        public TurmaController(ITurmaCRUD servicoDeCrud) : base(servicoDeCrud)
        {
        }

        public override IList<DTODeExibicao> ObterExibicoes()
        {
            return new List<DTODeExibicao>()
            {
                new DTODeExibicao()
                {
                    Id = 1,
                    Descricao = "Todos",
                    Campos = new List<DTODeCamposDaExibicao>()
                    {
                        new DTODeCamposDaExibicao()
                        {
                            Descricao = "Id",
                            Nome = "id",
                        },
                        new DTODeCamposDaExibicao()
                        {
                            Descricao = "Descrição",
                            Nome = "descricao"
                        }
                    }
                }
            };
        }
    }
}
