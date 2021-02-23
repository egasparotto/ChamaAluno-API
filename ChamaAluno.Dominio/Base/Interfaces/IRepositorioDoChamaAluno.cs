using ChamaAluno.Dominio.Base.Entidades;

using EGF.Dominio.Repositorios;

namespace ChamaAluno.Dominio.Base.Interfaces
{
    public interface IRepositorioDoChamaAluno<TEntidade> : IRepositorioComId<int, TEntidade>
        where TEntidade : EntidadeDoChamaAluno
    {
    }
}
