
using EGF.Dominio.Contextos;
using EGF.Dominio.Fabricas;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using System;

namespace ChamaAluno.Dados.Contexto
{
    public class ContextoDaAplicacao : EGF.Dados.EFCore.Contextos.Contexto, IContexto
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public ContextoDaAplicacao(IFabricaDeConexao fabrica) : base(fabrica)
        {

        }

        public override void MapearBancoDeDados(ModelBuilder modelBuilder)
        {
            InicializadorDeMapeamentos.InicializaMapeamentos(modelBuilder);
        }
    }
}
