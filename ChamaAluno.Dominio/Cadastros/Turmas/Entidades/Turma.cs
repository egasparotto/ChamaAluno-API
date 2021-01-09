
using EGF.Dominio.Entidades;

namespace ChamaAluno.Dominio.Cadastros.Turmas.Entidades
{
    public class Turma : EntidadeComId
    {
        public string Descricao { get; set; }

        public override string ToString()
        {
            return Descricao;
        }
    }
}
