using EGF.DTOs.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamaAluno.DTOs.Framework.Exibicoes
{
    public class DTODeExibicao : DTODeEntidadeComID
    {
        public string Descricao { get; set; }
        public IList<DTODeCamposDaExibicao> Campos { get; set; }
    }
}
