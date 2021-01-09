
using ChamaAluno.Dados.Base.Mapeamento;
using ChamaAluno.Dominio.Cadastros.Alunos.Entidades;

using Microsoft.EntityFrameworkCore;

namespace ChamaAluno.Dados.Cadastros.Alunos.Mapeamentos
{
    class MapeamentoDeAluno : MapeamentoBase<Aluno>
    {
        protected override string NomeTabela => "ALUNOS";

        protected override void MapeiaColunas()
        {
            Builder.Property(x => x.Nome).HasColumnName("NOME");
            Builder.Property(x => x.CPF).HasColumnName("CPF");
            Builder.Property(x => x.RG).HasColumnName("RG");
            Builder.Property(x => x.Foto).HasColumnName("FOTO");

            Builder.Property(x => x.IdDaTurma).HasColumnName("IDDATURMA").HasColumnType("int");

            Builder.HasOne(x => x.Turma).WithMany().HasForeignKey(x => x.IdDaTurma).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
