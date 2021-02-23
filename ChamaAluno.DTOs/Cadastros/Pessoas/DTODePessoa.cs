using ChamaAluno.DTOs.Base;

namespace ChamaAluno.DTOs.Cadastros.Pessoas
{
    public class DTODePessoa : DTODoChamaAluno
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Foto { get; set; }
    }
}
