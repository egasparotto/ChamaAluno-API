using ChamaAluno.Dominio.Base.Atributos.Validadores;
using ChamaAluno.Dominio.Cadastros.Pessoas.Entidades;

using EGF.Dominio.Autenticacao.Perfis.Entidades;

namespace ChamaAluno.Dominio.Cadastros.Colaboradores.Entidades
{
    public class Colaborador : Pessoa
    {
        public Colaborador()
        {
        }

        [Requerido]
        public string Email { get; set; }

        [Requerido]
        public string Senha { get; set; }

        public string Telefone { get; set; }

        [Requerido]
        public bool DoisFatores { get; set; } = false;

        public string ChaveDoisFatores { get; set; }

        [Requerido]
        public bool EmailConfirmado { get; set; }

        [Requerido]
        public int IdDoPerfil { get; set; }

        public Perfil Perfil { get; set; }
    }
}
