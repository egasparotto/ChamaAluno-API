
using EGF.Dominio.Contextos;
using EGF.Dominio.Fabricas;

using Microsoft.EntityFrameworkCore;

namespace ChamaAluno.Dados.Contexto
{
    public class ContextoDaAplicacao : EGF.Dados.EFCore.Contextos.Contexto, IContexto
    {
        public ContextoDaAplicacao(IFabricaDeConexao fabrica) : base(fabrica)
        {

        }

        public override void MapearBancoDeDados(ModelBuilder modelBuilder)
        {
            InicializadorDeMapeamentos.InicializaMapeamentos(modelBuilder);
        }
    }
}
