using ChamaAluno.Dominio.Base.Entidades;

using EGF.Dominio.Servicos;

namespace ChamaAluno.Dominio.Base.Interfaces
{
    public interface IServicoDePersistenciaDoChamaAluno<TEntidade> : IServicoDePersistencia<int, TEntidade>
        where TEntidade : EntidadeDoChamaAluno
    {
    }
}
