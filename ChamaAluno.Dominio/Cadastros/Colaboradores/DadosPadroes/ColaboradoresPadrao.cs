using ChamaAluno.Dominio.Cadastros.Colaboradores.Entidades;

using System.Collections.Generic;

namespace ChamaAluno.Dominio.Cadastros.Colaboradores.DadosPadroes
{
    public class ColaboradoresPadrao
    {
        public static Colaborador[] Obtem()
        {
            List<Colaborador> lista = new List<Colaborador>();
            lista.Add(new Colaborador()
            {
                Id = 1,
                Nome = "Usuário Mestre",
                Email = "Mestre",
                Senha = "CclrsUlmNI3cQWINMvkUDT+7BdV1P92R3uMDlVoeKku4wcMI",
                IdDoPerfil = 1
            });
            return lista.ToArray();
        }
    }
}