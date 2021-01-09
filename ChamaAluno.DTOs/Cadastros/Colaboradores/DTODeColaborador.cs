using ChamaAluno.DTOs.Cadastros.Pessoas;

namespace ChamaAluno.DTOs.Cadastros.Colaboradores
{
    public class DTODeColaborador : DTODePessoa
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdDoPerfil { get; set; }
        public string DescricaoDoPerfil { get; set; }
    }
}
