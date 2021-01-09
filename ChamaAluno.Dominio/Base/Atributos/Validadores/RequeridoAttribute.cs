
using System;
using System.ComponentModel.DataAnnotations;

namespace ChamaAluno.Dominio.Base.Atributos.Validadores
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RequeridoAttribute : ValidationAttribute
    {
        public RequeridoAttribute() : base("O Campo é de preenchimento obrigatório.")
        {
        }

        public bool PermiteStringsEmBranco { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            // only check string length if empty strings are not allowed
            var stringValue = value as string;
            if (stringValue != null && !PermiteStringsEmBranco)
            {
                return stringValue.Trim().Length != 0;
            }
            return true;
        }
    }
}
