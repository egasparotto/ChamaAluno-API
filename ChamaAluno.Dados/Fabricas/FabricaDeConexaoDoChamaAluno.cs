using EGF.Dados.EFCore.SQLServer.Fabricas;
using EGF.Licenciamento.Core.Licencas.Gerenciadores;

namespace ChamaAluno.Dados.Fabricas
{
    public class FabricaDeConexaoDoChamaAluno : FabricaDeConexaoSQLServer
    {
        public FabricaDeConexaoDoChamaAluno(IGerenciadorDeLicenca gerenciadorDeLicenca) : base(gerenciadorDeLicenca, "ChamaAluno.Dados")
        {
        }
    }
}
