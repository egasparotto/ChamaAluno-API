using ChamaAluno.Dominio.Base.Entidades;

using System.Collections.Generic;
using System.Linq;

namespace ChamaAluno.Dominio.Base.Interfaces
{
    public interface IServicoComListagem<TEntidade> : IServicoDePersistenciaDoChamaAluno<TEntidade>
        where TEntidade : EntidadeDoChamaAluno
    {
        IQueryable<TEntidade> Buscar(string termo);
        IQueryable<TEntidade> Buscar(string termo, string campo);
        void Remover(IEnumerable<TEntidade> entidade);
    }
}