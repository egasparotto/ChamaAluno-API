using ChamaAluno.DTOs.Base;

using System.Collections.Generic;

namespace ChamaAluno.DTOs.Framework.Exibicoes
{
    public class DTODeExibicao : DTODoChamaAluno
    {
        public string Descricao { get; set; }
        public IList<DTODeCamposDaExibicao> Campos { get; set; }
    }
}
