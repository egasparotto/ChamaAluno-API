using ChamaAluno.Dominio.Cadastros.Pessoas.Entidades;

using System.ComponentModel.DataAnnotations;

namespace ChamaAluno.Dominio.Cadastros.Pessoas.Validadores
{
    public class ValidadorDeCPFOuRGDaPessoa : ValidationAttribute
    {
        public ValidadorDeCPFOuRGDaPessoa()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Pessoa pessoa = (Pessoa)validationContext.ObjectInstance;
            if (string.IsNullOrEmpty(pessoa.CPF) && string.IsNullOrEmpty(pessoa.RG))
            {
                return new ValidationResult("Deve ser preenchido o RG ou o CPF.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
