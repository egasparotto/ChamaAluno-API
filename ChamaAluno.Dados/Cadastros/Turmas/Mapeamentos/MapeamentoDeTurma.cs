using ChamaAluno.Dados.Base.Mapeamentos;
using ChamaAluno.Dominio.Cadastros.Turmas.Entidades;

using Microsoft.EntityFrameworkCore;

namespace ChamaAluno.Dados.Cadastros.Turmas.Mapeamentos
{
    public class MapeamentoDeTurma : MapeamentoBase<Turma>
    {
        protected override string NomeTabela => "TURMAS";

        protected override void MapeiaColunas()
        {
            Builder.Property(x => x.Descricao).HasColumnName("DESCRICAO");
        }
    }
}
