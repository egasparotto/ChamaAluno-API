using ChamaAluno.Dominio.Base.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ChamaAluno.Dominio.Base.Utils
{
    public static class ExtensoesIQueryable
    {
        public static IQueryable<T> Where<T>(this IQueryable<T> origem, string valor, params string[] propriedades)
        {
            if (string.IsNullOrEmpty(valor))
            {
                return origem;
            }
            Expression<Func<T, bool>> condicao = null;
            foreach (string propriedade in propriedades)
            {
                if (condicao == null)
                {
                    condicao = ToLambdaWhere<T>(propriedade, valor);
                }
                else
                {
                    condicao = Or(condicao, ToLambdaWhere<T>(propriedade, valor));
                }
            }
            return origem.Where(condicao);
        }
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> origem, params Tuple<string, string>[] propriedades)
        {
            IOrderedQueryable<T> retorno;
            if (propriedades[0].Item2 == "desc")
            {
                retorno = origem.OrderByDescending(ToLambda<T>(propriedades[0].Item1));
            }
            else
            {
                retorno = origem.OrderBy(ToLambda<T>(propriedades[0].Item1));
            }
            for (int i = 1; i < propriedades.Length; i++)
            {
                if (propriedades[i].Item2 == "desc")
                {
                    retorno = retorno.ThenByDescending(ToLambda<T>(propriedades[i].Item1));
                }
                else
                {
                    retorno = retorno.ThenBy(ToLambda<T>(propriedades[i].Item1));
                }
            }
            return retorno;
        }
        private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
        }
        private static Expression<Func<T, bool>> ToLambdaWhere<T>(string propertyName, string valor)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propertyName);
            Type tipoDaPropriedade = typeof(T).GetProperty(propertyName).PropertyType;
            if (Nullable.GetUnderlyingType(tipoDaPropriedade) != null)
            {
                tipoDaPropriedade = Nullable.GetUnderlyingType(tipoDaPropriedade);
            }
            object valorConvertido;
            try
            {
                valorConvertido = Convert.ChangeType(valor, tipoDaPropriedade);
            }
            catch
            {
                return Expression.Lambda<Func<T, bool>>(Expression.Constant(false), parameter);
            }
            var propriedadeConvertida = Expression.Convert(property, valorConvertido.GetType());
            var valorExp = Expression.Constant(valorConvertido);
            if (valorConvertido.GetType() == typeof(string))
            {
                MethodInfo metodo = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                var contem = Expression.Call(propriedadeConvertida, metodo, valorExp);
                return Expression.Lambda<Func<T, bool>>(contem, parameter);
            }
            else
            {
                return Expression.Lambda<Func<T, bool>>(Expression.Equal(propriedadeConvertida, valorExp), parameter);
            }
        }

        private static Expression<Func<T, bool>> Or<T>(Expression<Func<T, bool>> exprA, Expression<Func<T, bool>> exprB)
        {
            return Expression.Lambda<Func<T, bool>>(
                Expression.OrElse(
                    exprA.Body,
                    new ExpressionParameterReplacer(exprB.Parameters, exprA.Parameters).Visit(exprB.Body)),
                exprA.Parameters);
        }

        private class ExpressionParameterReplacer : ExpressionVisitor
        {
            public ExpressionParameterReplacer(IList<ParameterExpression> fromParameters, IList<ParameterExpression> toParameters)
            {
                ParameterReplacements = new Dictionary<ParameterExpression, ParameterExpression>();
                for (int i = 0; i != fromParameters.Count && i != toParameters.Count; i++)
                    ParameterReplacements.Add(fromParameters[i], toParameters[i]);
            }
            private IDictionary<ParameterExpression, ParameterExpression> ParameterReplacements
            {
                get;
                set;
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                ParameterExpression replacement;
                if (ParameterReplacements.TryGetValue(node, out replacement))
                    node = replacement;
                return base.VisitParameter(node);
            }
        }
    }
}
