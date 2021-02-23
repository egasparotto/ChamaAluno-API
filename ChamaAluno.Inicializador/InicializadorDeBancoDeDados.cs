using ChamaAluno.Dados.Contexto;
using ChamaAluno.Dados.Fabricas;

using EGF.Dados.EFCore.UnidadesDeTrabalho;
using EGF.Dominio.Contextos;
using EGF.Dominio.Fabricas;
using EGF.Dominio.UnidadesDeTrabalho;
using EGF.Licenciamento.Core.Licencas.Gerenciadores;
using EGF.Licenciamento.WEB.Gerenciadores;

using Microsoft.Extensions.DependencyInjection;

namespace ChamaAluno.Inicializador
{
    public static class InicializadorDeBancoDeDados
    {
        public static IServiceCollection IniciarBancoDeDados(this IServiceCollection services)
        {
            return services.AddScoped<IContexto, ContextoDaAplicacao>()
                           .AddScoped<IFabricaDeConexao, FabricaDeConexaoDoChamaAluno>()
                           .AddScoped<IGerenciadorDeLicenca, GerenciadorDeLicencaWEB>()
                           .AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();
        }
    }
}
