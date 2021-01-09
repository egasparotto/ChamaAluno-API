
using ChamaAluno.Dados.Autenticacao.Perfis.Mapeamentos;
using ChamaAluno.Dados.Cadastros.Alunos.Mapeamentos;
using ChamaAluno.Dados.Cadastros.Colaboradores.Mapeamentos;
using ChamaAluno.Dados.Cadastros.Responsaveis.Mapeamentos;
using ChamaAluno.Dados.Cadastros.Turmas.Mapeamentos;

using Microsoft.EntityFrameworkCore;

namespace ChamaAluno.Dados.Contexto
{
    public static class InicializadorDeMapeamentos
    {
        public static void InicializaMapeamentos(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeamentoDeAluno());
            modelBuilder.ApplyConfiguration(new MapeamentoDeAlunoDoResponsavel());
            modelBuilder.ApplyConfiguration(new MapeamentoDeColaborador());
            modelBuilder.ApplyConfiguration(new MapeamentoDeResponsavel());
            modelBuilder.ApplyConfiguration(new MapeamentoDeTurma());
            modelBuilder.ApplyConfiguration(new MapeamentoDePerfil());
        }
    }
}