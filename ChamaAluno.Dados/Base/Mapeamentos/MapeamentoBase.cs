using ChamaAluno.Dominio.Base.Entidades;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChamaAluno.Dados.Base.Mapeamentos
{
    public abstract class MapeamentoBase<T> : EGF.Dados.EFCore.Mapeamentos.Mapeamento<T>
        where T : EntidadeDoChamaAluno
    {
        protected EntityTypeBuilder<T> Builder { get; private set; }
        protected abstract string NomeTabela { get; }
        protected abstract void MapeiaColunas();
        protected virtual T[] DadosPadrao { get; }

        protected virtual void MapeiaTabela()
        {
            Builder.ToTable(NomeTabela);
            Builder.Property(x => x.Id).HasColumnName("ID");
            Builder.HasKey(x => x.Id).HasName($"PK_{NomeTabela}");
        }

        protected override void Mapear(EntityTypeBuilder<T> builder)
        {
            Builder = builder;
            MapeiaTabela();
            MapeiaColunas();
            if (DadosPadrao != null && DadosPadrao.Length > 0)
            {
                builder.HasData(DadosPadrao);
            }
        }
    }
}
