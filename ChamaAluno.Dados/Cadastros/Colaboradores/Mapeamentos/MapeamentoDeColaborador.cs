using ChamaAluno.Dados.Base.Mapeamentos;
using ChamaAluno.Dominio.Cadastros.Colaboradores.DadosPadroes;
using ChamaAluno.Dominio.Cadastros.Colaboradores.Entidades;

using Microsoft.EntityFrameworkCore;

namespace ChamaAluno.Dados.Cadastros.Colaboradores.Mapeamentos
{
    class MapeamentoDeColaborador : MapeamentoBase<Colaborador>
    {
        protected override string NomeTabela => "COLABORADORES";

        protected override void MapeiaColunas()
        {
            Builder.Property(x => x.Id).HasColumnName("ID").HasColumnType("int");
            Builder.Property(x => x.Nome).HasColumnName("NOME");
            Builder.Property(x => x.CPF).HasColumnName("CPF");
            Builder.Property(x => x.RG).HasColumnName("RG");
            Builder.Property(x => x.Foto).HasColumnName("FOTO");

            Builder.Property(x => x.Email).HasColumnName("EMAIL");
            Builder.Property(x => x.Senha).HasColumnName("SENHA");
            Builder.Property(x => x.Telefone).HasColumnName("TELEFONE");
            Builder.Property(x => x.DoisFatores).HasColumnName("DOISFATORES");
            Builder.Property(x => x.ChaveDoisFatores).HasColumnName("CHAVEDOISFATORES");
            Builder.Property(x => x.EmailConfirmado).HasColumnName("EMAILCONFIRMADO");
            Builder.Property(x => x.IdDoPerfil).HasColumnName("IDDOPERFIL");

            Builder.HasOne(x => x.Perfil).WithMany().HasForeignKey(x => x.IdDoPerfil).OnDelete(DeleteBehavior.Restrict);
        }


        protected override Colaborador[] DadosPadrao => ColaboradoresPadrao.Obtem();
    }
}