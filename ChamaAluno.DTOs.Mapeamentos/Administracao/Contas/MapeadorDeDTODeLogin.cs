﻿using AutoMapper;

using ChamaAluno.Dominio.Cadastros.Colaboradores.Entidades;
using ChamaAluno.DTOs.Administracao.Contas;

using EGF.DTOs.Mapeamentos.Base;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamaAluno.DTOs.Mapeamentos.Administracao.Contas
{
    public class MapeadorDeDTODeLogin : MapeadorDeDTO<Colaborador, DTODeLogin>
    {
        public override void DTOParaEntidade(IMappingExpression<DTODeLogin, Colaborador> mapeamento)
        {
            mapeamento
                .ForMember(x => x.Senha, y => y.Ignore());
        }

        public override void EntidadeParaDTO(IMappingExpression<Colaborador, DTODeLogin> mapeamento)
        {
            mapeamento
                .ForMember(x => x.Senha, y => y.Ignore());
        }
    }
}
