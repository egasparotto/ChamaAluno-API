
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ChamaAluno.Dominio.Base.Excecoes
{
    public class ErroDeValidacaoDeEntidade : Exception
    {
        public IEnumerable<ValidationResult> Erros { get; set; }

        public override string Message { get => ObterMensagemDeErro(); }

        protected string ObterMensagemDeErro()
        {
            return string.Join("<br>", Erros.Select(x =>
            {
                if (x.MemberNames != null && x.MemberNames.Count() > 0)
                {
                    return "<b>" + string.Join(" ", x.MemberNames) + "</b>: " + x.ErrorMessage;
                }
                else
                {
                    return "<b>-</b> " + x.ErrorMessage;
                }
            }));
        }

        public ErroDeValidacaoDeEntidade(IEnumerable<ValidationResult> erros)
        {
            Erros = erros;
        }

        public ErroDeValidacaoDeEntidade(string mensagem)
        {
            ValidationResult erro = new ValidationResult(mensagem);
            Erros = new List<ValidationResult>
            {
                erro
            };
        }
    }
}
