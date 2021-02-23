using ChamaAluno.ServicosDeAplicacao.CRUD.Cadastros.Alunos;
using ChamaAluno.ServicosDeAplicacao.CRUD.Cadastros.Colaboradores;
using ChamaAluno.ServicosDeAplicacao.CRUD.Cadastros.Responsaveis;
using ChamaAluno.ServicosDeAplicacao.CRUD.Cadastros.Turmas;

using Microsoft.Extensions.DependencyInjection;

namespace ChamaAluno.Inicializador
{
    public static class InicializadorDeCRUD
    {
        public static IServiceCollection IniciarCRUD(this IServiceCollection services)
        {
            return services
                .AddScoped<IColaboradorCRUD, ColaboradorCRUD>()
                .AddScoped<IAlunoCRUD, AlunoCRUD>()
                .AddScoped<IResponsavelCRUD, ResponsavelCRUD>()
                .AddScoped<ITurmaCRUD, TurmaCRUD>();
        }
    }
}
