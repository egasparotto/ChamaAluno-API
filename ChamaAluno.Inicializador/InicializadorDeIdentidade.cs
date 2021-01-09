using ChamaAluno.Dominio.Base.Utils;
using ChamaAluno.Dominio.Cadastros.Colaboradores.Entidades;
using ChamaAluno.Dominio.Cadastros.Colaboradores.Servicos;

using EGF.Dominio.Autenticacao.Perfis.Entidades;
using EGF.Dominio.Autenticacao.Perfis.Servicos;
using EGF.Dominio.Autenticacao.Usuarios.Entidades;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Text;

namespace ChamaAluno.Inicializador
{
    public static class InicializadorDeIdentidade
    {
        public static IServiceCollection IniciarIdentidade(this IServiceCollection services, string chaveJWT)
        {


            services.AddIdentityCore<Colaborador>().AddDefaultTokenProviders();
            services.AddScoped<IPasswordHasher<Colaborador>, Criptografia<Colaborador>>();
            services.AddTransient<IUserStore<Colaborador>, ServicoDeColaborador>();
            services.AddTransient<IRoleStore<Perfil>, ServicoDePerfil>();
            services.AddTransient<IServicoDeColaborador, ServicoDeColaborador>();
            services.AddTransient<IServicoDePerfil, ServicoDePerfil>();
            services.AddTransient<UserManager<Colaborador>>();
            services.AddTransient<SignInManager<Colaborador>>();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 1;
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
             options.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuer = false,
                 ValidateAudience = false,
                 ValidateLifetime = true,
                 ValidateIssuerSigningKey = true,
                 RequireExpirationTime = false,
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveJWT)),
                 ClockSkew = TimeSpan.Zero
             });

            return services;

        }
    }
}