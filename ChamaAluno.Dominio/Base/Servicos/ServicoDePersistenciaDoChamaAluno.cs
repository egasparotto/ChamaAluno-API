using ChamaAluno.Dominio.Base.Entidades;
using ChamaAluno.Dominio.Base.Interfaces;

using EGF.Dominio.Servicos;

namespace ChamaAluno.Dominio.Base.Servicos
{
    public class ServicoDePersistenciaDoChamaAluno<TEntidade, TRepositorio> : ServicoDePersistencia<int, TEntidade, TRepositorio>, IServicoDePersistenciaDoChamaAluno<TEntidade>
        where TEntidade : EntidadeDoChamaAluno
        where TRepositorio : IRepositorioDoChamaAluno<TEntidade>
    {
        public ServicoDePersistenciaDoChamaAluno(TRepositorio repositorio) : base(repositorio)
        {
        }
    }
}
