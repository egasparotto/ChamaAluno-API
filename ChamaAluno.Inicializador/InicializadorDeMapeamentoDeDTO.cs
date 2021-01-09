using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChamaAluno.DTOs.Mapeamentos.Cadastros.Colaboradores;
using ChamaAluno.DTOs.Mapeamentos.Cadastros.Alunos;
using ChamaAluno.DTOs.Mapeamentos.Cadastros.Responsaveis;
using ChamaAluno.DTOs.Mapeamentos.Cadastros.Turmas;
using ChamaAluno.DTOs.Mapeamentos.Administracao.Contas;
using ChamaAluno.DTOs.Mapeamentos.Cadastros.Pessoas;

namespace ChamaAluno.Inicializador
{
    public static class InicializadorDeMapeamentoDeDTO
    {
        public static IServiceCollection IniciarMapeamentosDeDTO(this IServiceCollection services)
        {
            return services
                .AddScoped(provider => new MapperConfiguration(config => RegistrarMapeamentos(provider, config)).CreateMapper())
                .AddScoped<MapeadorDeDTODeColaborador>()
                .AddScoped<MapeadorDeDTODeAluno>()
                .AddScoped<MapeadorDeDTODeAlunoDoResponsavel>()
                .AddScoped<MapeadorDeDTODeResponsavel>()
                .AddScoped<MapeadorDeDTODeTurma>()
                .AddScoped<MapeadorDeDTODeLogin>()
                .AddScoped<MapeadorDeDTODePessoa>();
        }

        private static void RegistrarMapeamentos(IServiceProvider provider, IMapperConfigurationExpression config)
        {
            config.ConstructServicesUsing(provider.GetService);

            config.AddProfile(provider.GetService<MapeadorDeDTODeColaborador>());
            config.AddProfile(provider.GetService<MapeadorDeDTODeAluno>());
            config.AddProfile(provider.GetService<MapeadorDeDTODeAlunoDoResponsavel>());
            config.AddProfile(provider.GetService<MapeadorDeDTODeResponsavel>());
            config.AddProfile(provider.GetService<MapeadorDeDTODeTurma>());
            config.AddProfile(provider.GetService<MapeadorDeDTODeLogin>());
            config.AddProfile(provider.GetService<MapeadorDeDTODePessoa>());
        }
    }
}
