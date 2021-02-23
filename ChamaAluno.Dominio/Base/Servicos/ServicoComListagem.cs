using ChamaAluno.Dominio.Base.Entidades;
using ChamaAluno.Dominio.Base.Interfaces;
using ChamaAluno.Dominio.Base.Utils;

using System.Collections.Generic;
using System.Linq;

namespace ChamaAluno.Dominio.Base.Servicos
{
    public class ServicoComListagem<TEntidade, TRepositorio> : ServicoDePersistenciaDoChamaAluno<TEntidade, TRepositorio>, IServicoComListagem<TEntidade>
        where TEntidade : EntidadeDoChamaAluno
        where TRepositorio : IRepositorioDoChamaAluno<TEntidade>
    {
        public ServicoComListagem(TRepositorio repositorio) : base(repositorio)
        {
        }


        public IQueryable<TEntidade> Buscar(string termo)
        {
            IQueryable<TEntidade> lista = Repositorio.Buscar();
            if (!string.IsNullOrEmpty(termo))
            {
                lista = lista.Where(termo, typeof(TEntidade).GetProperties().Select(x => x.Name).ToArray());
            }
            return lista;
        }


        public IQueryable<TEntidade> Buscar(string termo, string campo)
        {
            IQueryable<TEntidade> lista = Repositorio.Buscar();
            if (!string.IsNullOrEmpty(termo))
            {
                lista = lista.Where(termo, campo);
            }
            return lista;
        }

        public virtual void Remover(IEnumerable<TEntidade> entidade)
        {
            foreach (TEntidade item in entidade)
            {
                Repositorio.Remover(item);
            }
        }
    }
}
