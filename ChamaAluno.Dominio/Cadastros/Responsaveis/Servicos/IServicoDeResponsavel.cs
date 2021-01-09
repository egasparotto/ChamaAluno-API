using ChamaAluno.Dominio.Base.Interfaces;
using ChamaAluno.Dominio.Cadastros.Alunos.Entidades;
using ChamaAluno.Dominio.Cadastros.Responsaveis.Entidades;

using System;
using System.Collections.Generic;

namespace ChamaAluno.Dominio.Cadastros.Responsaveis.Servicos
{
    public interface IServicoDeResponsavel : IServicoComListagem<Responsavel>
    {
        IEnumerable<AlunoDoResponsavel> ObterAlunosAutorizados(int idDoResponsavel, DateTime data);
    }
}
