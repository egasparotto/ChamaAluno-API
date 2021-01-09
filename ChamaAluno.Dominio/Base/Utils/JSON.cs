
using Newtonsoft.Json;

using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace ChamaAluno.Dominio.Base.Utils
{
    public static class JSON
    {
        public static dynamic JSONDaTabela(IEnumerable<object> lista, int draw, int recordsTotal, int recordsFiltered, bool convertePropriedadesParaString = true)
        {
            dynamic retorno = new ExpandoObject();
            if (convertePropriedadesParaString)
            {
                retorno.data = PreparaListaParaResposta(lista);
            }
            else
            {
                retorno.data = lista;
            }
            retorno.draw = draw;
            retorno.recordsTotal = recordsTotal;
            retorno.recordsFiltered = recordsFiltered;
            return retorno;
        }

        public static string JSONParaResposta(object objeto, string descricaoDaEntidade)
        {
            dynamic resposta = new ExpandoObject();
            resposta.Entidade = objeto;
            if (string.IsNullOrEmpty(objeto?.ToString()))
            {
                resposta.Descricao = descricaoDaEntidade;
            }
            else
            {
                resposta.Descricao = descricaoDaEntidade + " - " + objeto.ToString();
            }
            var opcoes = new JsonSerializerSettings();
            opcoes.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return JsonConvert.SerializeObject(resposta, opcoes);
        }

        private static dynamic PreparaListaParaResposta(IEnumerable<object> lista)
        {
            return lista.AsParallel().Select(x =>
            {
                dynamic retorno = new ExpandoObject();
                var tipo = x.GetType();
                foreach (var prop in tipo.GetProperties())
                {
                    (retorno as IDictionary<string, object>)[prop.Name] = prop.GetValue(x)?.ToString();
                }
                return retorno;
            });
        }
    }
}
