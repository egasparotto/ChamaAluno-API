using EGF.DTOs.Entidades;

using System;

namespace ChamaAluno.DTOs.Cadastros.Alunos
{
    public class DTODeAlunoDoResponsavel : DTODeEntidadeComID
    {
        public int IdDoResponsavel { get; set; }
        public string NomeDoResponsavel { get; set; }
        public DateTime InicioDaValidade { get; set; }
        public DateTime? TerminoDaValidade { get; set; }
        public bool Domingo { get; set; }
        public bool Segunda { get; set; }
        public bool Terca { get; set; }
        public bool Quarta { get; set; }
        public bool Quinta { get; set; }
        public bool Sexta { get; set; }
        public bool Sabado { get; set; }
    }
}
