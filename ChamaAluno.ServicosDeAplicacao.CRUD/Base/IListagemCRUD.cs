using ChamaAluno.DTOs.Base;

using System.Collections.Generic;
using System.Linq;

namespace ChamaAluno.ServicosDeAplicacao.CRUD.Base
{
    public interface IListagemCRUD<TDTO> : IChamaAlunoCRUD<TDTO>
        where TDTO : DTODoChamaAluno
    {
        public IEnumerable<TDTO> ListarParaGrid(string pesquisa);
    }
}
