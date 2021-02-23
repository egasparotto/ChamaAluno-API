using ChamaAluno.Dominio.Cadastros.Alunos.Servicos;
using ChamaAluno.Dominio.Cadastros.Colaboradores.Servicos;
using ChamaAluno.Dominio.Cadastros.Responsaveis.Servicos;
using ChamaAluno.Dominio.Cadastros.Turmas.Servicos;

using EGF.Dominio.Autenticacao.Perfis.Servicos;

using Microsoft.Extensions.DependencyInjection;

namespace ChamaAluno.Inicializador
{
    public static class InicializadorDeServicos
    {
        public static IServiceCollection IniciarServicos(this IServiceCollection services)
        {
            return services.AddScoped<IServicoDeColaborador, ServicoDeColaborador>()
                           .AddScoped<IServicoDePerfil, ServicoDePerfil>()
                           .AddScoped<IServicoDeTurma, ServicoDeTurma>()
                           .AddScoped<IServicoDeResponsavel, ServicoDeResponsavel>()
                           .AddScoped<IServicoDeAluno, ServicoDeAluno>();
        }
    }
}
