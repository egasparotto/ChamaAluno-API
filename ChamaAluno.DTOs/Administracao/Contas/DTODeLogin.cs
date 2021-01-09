using EGF.DTOs.Entidades;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamaAluno.DTOs.Administracao.Contas
{
    public class DTODeLogin: DTODeEntidade
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
