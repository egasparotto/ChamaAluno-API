using ChamaAluno.Dados.Cadastros.Alunos.Repositorios;
using ChamaAluno.Dados.Cadastros.Colaboradores.Repositorios;
using ChamaAluno.Dados.Cadastros.Responsaveis.Repositorios;
using ChamaAluno.Dados.Cadastros.Turmas.Repositorios;
using ChamaAluno.Dominio.Cadastros.Alunos.Repositorios;
using ChamaAluno.Dominio.Cadastros.Alunos.Servicos;
using ChamaAluno.Dominio.Cadastros.Colaboradores.Repositorios;
using ChamaAluno.Dominio.Cadastros.Colaboradores.Servicos;
using ChamaAluno.Dominio.Cadastros.Responsaveis.Repositorios;
using ChamaAluno.Dominio.Cadastros.Responsaveis.Servicos;
using ChamaAluno.Dominio.Cadastros.Turmas.Repositorios;
using ChamaAluno.Dominio.Cadastros.Turmas.Servicos;

using EGF.Dados.EFCore.Autenticacao.Perfis.Repositorios;
using EGF.Dominio.Autenticacao.Perfis.Repositorios;
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
