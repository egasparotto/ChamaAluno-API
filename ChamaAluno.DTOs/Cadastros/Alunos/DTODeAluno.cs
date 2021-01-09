using ChamaAluno.DTOs.Cadastros.Pessoas;

using System.Collections.Generic;

namespace ChamaAluno.DTOs.Cadastros.Alunos
{
    public class DTODeAluno : DTODePessoa
    {
        public int IdDaTurma { get; set; }
        public string DescricaoDaTurma { get; set; }
        public IEnumerable<DTODeAlunoDoResponsavel> AlunosResponsaveis { get; set; }
    }
}
