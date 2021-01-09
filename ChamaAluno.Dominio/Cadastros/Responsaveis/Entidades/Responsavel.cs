using ChamaAluno.Dominio.Cadastros.Alunos.Entidades;
using ChamaAluno.Dominio.Cadastros.Pessoas.Entidades;

using System.Collections.Generic;

namespace ChamaAluno.Dominio.Cadastros.Responsaveis.Entidades
{
    public class Responsavel : Pessoa
    {
        public IList<AlunoDoResponsavel> AlunosResponsaveis { get; set; }

        public string Cartao { get; set; }

        public Responsavel()
        {
            AlunosResponsaveis = new List<AlunoDoResponsavel>();
        }
    }
}
