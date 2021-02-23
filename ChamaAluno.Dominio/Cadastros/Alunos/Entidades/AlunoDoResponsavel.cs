
using ChamaAluno.Dominio.Base.Atributos.Validadores;
using ChamaAluno.Dominio.Base.Entidades;
using ChamaAluno.Dominio.Cadastros.Responsaveis.Entidades;

using System;

namespace ChamaAluno.Dominio.Cadastros.Alunos.Entidades
{
    public class AlunoDoResponsavel : EntidadeDoChamaAluno
    {
        [Requerido]
        public int IdDoAluno { get; set; }
        public Aluno Aluno { get; set; }
        [Requerido]
        public int IdDoResponsavel { get; set; }
        public Responsavel Responsavel { get; set; }
        [Requerido]
        public DateTime InicioDaValidade { get; set; }
        public DateTime? TerminoDaValidade { get; set; }
        [Requerido]
        public bool Domingo { get; set; }
        [Requerido]
        public bool Segunda { get; set; }
        [Requerido]
        public bool Terca { get; set; }
        [Requerido]
        public bool Quarta { get; set; }
        [Requerido]
        public bool Quinta { get; set; }
        [Requerido]
        public bool Sexta { get; set; }
        [Requerido]
        public bool Sabado { get; set; }
    }
}
