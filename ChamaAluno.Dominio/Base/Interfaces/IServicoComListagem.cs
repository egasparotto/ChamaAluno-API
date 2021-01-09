using EGF.Dominio.Entidades;
using EGF.Dominio.Servicos;

using System.Collections.Generic;
using System.Linq;

namespace ChamaAluno.Dominio.Base.Interfaces
{
    public interface IServicoComListagem<TEntidade> : IServicoDePersistencia<TEntidade>
        where TEntidade : EntidadeComId
    {
        IQueryable<TEntidade> Buscar(string termo);
        IQueryable<TEntidade> Buscar(string termo, string campo);
        void Remover(IEnumerable<TEntidade> entidade);
    }
}