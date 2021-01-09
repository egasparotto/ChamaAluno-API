using ChamaAluno.Dominio.Base.Atributos.Validadores;
using ChamaAluno.Dominio.Cadastros.Pessoas.Entidades;
using ChamaAluno.Dominio.Cadastros.Turmas.Entidades;

using System.Collections.Generic;

namespace ChamaAluno.Dominio.Cadastros.Alunos.Entidades
{
    public class Aluno : Pessoa
    {
        [Requerido]
        public int IdDaTurma { get; set; }
        public Turma Turma { get; set; }
        public IList<AlunoDoResponsavel> AlunosResponsaveis { get; set; }

        public Aluno()
        {
            AlunosResponsaveis = new List<AlunoDoResponsavel>();
        }
    }
}
