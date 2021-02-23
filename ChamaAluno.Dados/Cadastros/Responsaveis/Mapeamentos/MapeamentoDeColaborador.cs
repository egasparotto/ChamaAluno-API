using ChamaAluno.Dados.Base.Mapeamentos;
using ChamaAluno.Dominio.Cadastros.Responsaveis.Entidades;

using Microsoft.EntityFrameworkCore;

namespace ChamaAluno.Dados.Cadastros.Responsaveis.Mapeamentos
{
    class MapeamentoDeResponsavel : MapeamentoBase<Responsavel>
    {
        protected override string NomeTabela => "RESPONSAVEIS";

        protected override void MapeiaColunas()
        {
            Builder.Property(x => x.Nome).HasColumnName("NOME");
            Builder.Property(x => x.CPF).HasColumnName("CPF");
            Builder.Property(x => x.RG).HasColumnName("RG");
            Builder.Property(x => x.Foto).HasColumnName("FOTO");
            Builder.Property(x => x.Cartao).HasColumnName("CARTAO");
        }
    }
}