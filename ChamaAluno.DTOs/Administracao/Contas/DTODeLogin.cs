using EGF.DTOs.Entidades;

namespace ChamaAluno.DTOs.Administracao.Contas
{
    public class DTODeLogin : DTODeEntidade
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
