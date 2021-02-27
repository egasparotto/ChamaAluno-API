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

        public override DbContextOptionsBuilder OpcoesAdicionais(DbContextOptionsBuilder options)
        {
            return options;
            //return options.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }
    }
}
