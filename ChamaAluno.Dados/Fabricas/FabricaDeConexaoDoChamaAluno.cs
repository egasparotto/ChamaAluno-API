﻿
using EGF.Dados.EFCore.Fabricas;
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