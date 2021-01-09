using ChamaAluno.Dados.Cadastros.Alunos.Repositorios;
using ChamaAluno.Dados.Cadastros.Colaboradores.Repositorios;
using ChamaAluno.Dados.Cadastros.Responsaveis.Repositorios;
using ChamaAluno.Dados.Cadastros.Turmas.Repositorios;
using ChamaAluno.Dominio.Cadastros.Alunos.Repositorios;
using ChamaAluno.Dominio.Cadastros.Colaboradores.Repositorios;
using ChamaAluno.Dominio.Cadastros.Responsaveis.Repositorios;
using ChamaAluno.Dominio.Cadastros.Turmas.Repositorios;

using EGF.Dados.EFCore.Autenticacao.Perfis.Repositorios;
using EGF.Dominio.Autenticacao.Perfis.Repositorios;

using Microsoft.Extensions.DependencyInjection;

namespace ChamaAluno.Inicializador
{
    public static class InicializadorDeRepositorios
    {
        public static IServiceCollection IniciarRepositorios(this IServiceCollection services)
        {
            return services.AddScoped<IRepositorioDeColaborador, RepositorioDeColaborador>()
                           .AddScoped<IRepositorioDePerfil, RepositorioDePerfil>()
                           .AddScoped<IRepositorioDeTurma, RepositorioDeTurma>()
                           .AddScoped<IRepositorioDeResponsavel, RepositorioDeResponsavel>()
                           .AddScoped<IRepositorioDeAluno, RepositorioDeAluno>()
                           .AddScoped<IRepositorioDeAlunoDoResponsavel, RepositorioDeAlunoDoResponsavel>();
        }
    }
}
