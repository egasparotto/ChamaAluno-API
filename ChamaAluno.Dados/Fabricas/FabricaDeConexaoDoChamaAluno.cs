using EGF.Dados.EFCore.SQLServer.Fabricas;
using EGF.Licenciamento.Core.Licencas.Gerenciadores;

using Microsoft.EntityFrameworkCore;

using System;

namespace ChamaAluno.Dados.Fabricas
{
    public class FabricaDeConexaoDoChamaAluno : FabricaDeConexaoSQLServer
    {
        public FabricaDeConexaoDoChamaAluno(IGerenciadorDeLicenca gerenciadorDeLicenca) : base(gerenciadorDeLicenca, "ChamaAluno.Dados")
        {
        }

#if DEBUG
        public override DbContextOptionsBuilder OpcoesAdicionais(DbContextOptionsBuilder options)
        {
            return options.EnableSensitiveDataLogging().LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }
#endif
    }
}
