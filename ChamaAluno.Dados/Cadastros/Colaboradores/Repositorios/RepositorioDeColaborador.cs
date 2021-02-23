
using ChamaAluno.Dados.Base.Repositorios;
using ChamaAluno.Dominio.Cadastros.Colaboradores.Entidades;
using ChamaAluno.Dominio.Cadastros.Colaboradores.Repositorios;

using EGF.Dominio.UnidadesDeTrabalho;

using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Threading.Tasks;

namespace ChamaAluno.Dados.Cadastros.Colaboradores.Repositorios
{
    public class RepositorioDeColaborador : RepositorioDoChamaAluno<Colaborador>, IRepositorioDeColaborador
    {
        public RepositorioDeColaborador(IUnidadeDeTrabalho unidadeDeTrabalho) : base(unidadeDeTrabalho)
        {

        }

        public override IQueryable<Colaborador> Buscar()
        {
            return base.Buscar().Include(x => x.Perfil);
        }

        public override async Task<IQueryable<Colaborador>> BuscarAsync()
        {
            return (await base.BuscarAsync()).Include(x => x.Perfil);
        }
    }
}
