
using ChamaAluno.Dominio.Base.Entidades;

namespace ChamaAluno.Dominio.Cadastros.Turmas.Entidades
{
    public class Turma : EntidadeDoChamaAluno
    {
        public string Descricao { get; set; }

        public override string ToString()
        {
            return Descricao;
        }
    }
}
