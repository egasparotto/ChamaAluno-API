using ChamaAluno.Dados.Base.Mapeamento;
using ChamaAluno.Dominio.Cadastros.Alunos.Entidades;

using Microsoft.EntityFrameworkCore;

namespace ChamaAluno.Dados.Cadastros.Alunos.Mapeamentos
{
    class MapeamentoDeAlunoDoResponsavel : MapeamentoBase<AlunoDoResponsavel>
    {
        protected override string NomeTabela => "ALUNOSRESP";

        protected override void MapeiaColunas()
        {
            Builder.Property(x => x.IdDoAluno).HasColumnName("IDDOALUNO");
            Builder.Property(x => x.IdDoResponsavel).HasColumnName("IDDORESPONSAVEL");
            Builder.Property(x => x.InicioDaValidade).HasColumnName("INICIODAVALIDADE");
            Builder.Property(x => x.TerminoDaValidade).HasColumnName("TERMINODAVALIDADE");
            Builder.Property(x => x.Domingo).HasColumnName("DOMINGO");
            Builder.Property(x => x.Segunda).HasColumnName("SEGUNDA");
            Builder.Property(x => x.Terca).HasColumnName("TERCA");
            Builder.Property(x => x.Quarta).HasColumnName("QUARTA");
            Builder.Property(x => x.Quinta).HasColumnName("QUINTA");
            Builder.Property(x => x.Sexta).HasColumnName("SEXTA");
            Builder.Property(x => x.Sabado).HasColumnName("SABADO");

            Builder.HasIndex(x => new { x.IdDoResponsavel, x.InicioDaValidade, x.TerminoDaValidade });

            Builder.HasOne(x => x.Aluno).WithMany(x => x.AlunosResponsaveis).HasForeignKey(x => x.IdDoAluno).OnDelete(DeleteBehavior.Cascade);
            Builder.HasOne(x => x.Responsavel).WithMany(x => x.AlunosResponsaveis).HasForeignKey(x => x.IdDoResponsavel).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
