using ChamaAluno.DTOs.Base;

using EGF.ServicosDeAplicacao.CRUD.Base;

namespace ChamaAluno.ServicosDeAplicacao.CRUD.Base
{
    public interface IChamaAlunoCRUD<TDTO> : ICRUD<int, TDTO>
        where TDTO : DTODoChamaAluno
    {
    }
}
