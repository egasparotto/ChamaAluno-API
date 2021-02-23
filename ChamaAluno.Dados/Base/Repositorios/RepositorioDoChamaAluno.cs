using ChamaAluno.Dominio.Base.Entidades;
using ChamaAluno.Dominio.Base.Interfaces;

using EGF.Dados.EFCore.Repositorios;
using EGF.Dominio.UnidadesDeTrabalho;

namespace ChamaAluno.Dados.Base.Repositorios
{
    public class RepositorioDoChamaAluno<TEntidade> : RepositorioComId<int, TEntidade>, IRepositorioDoChamaAluno<TEntidade>
        where TEntidade : EntidadeDoChamaAluno
    {
        public RepositorioDoChamaAluno(IUnidadeDeTrabalho unidadeDeTrabalho) : base(unidadeDeTrabalho)
        {
        }
    }
}
