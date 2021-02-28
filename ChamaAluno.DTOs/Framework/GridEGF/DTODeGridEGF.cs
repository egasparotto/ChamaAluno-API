using EGF.DTOs.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamaAluno.DTOs.Framework.GridEGF
{
    public class DTODeGridEGF<TDTO>
        where TDTO : DTODeEntidade
    {
        public TDTO[] Dados { get; set; }
        public DTODeOpcoesDoGridEGF Opcoes { get; set; }
    }
}
