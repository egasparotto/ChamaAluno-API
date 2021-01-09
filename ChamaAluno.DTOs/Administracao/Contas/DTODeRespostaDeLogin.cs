using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamaAluno.DTOs.Administracao.Contas
{
    public class DTODeRespostaDeLogin
    {
        public string Token { get; set; }
        public DTODeLogin Login { get; set; }
    }
}
