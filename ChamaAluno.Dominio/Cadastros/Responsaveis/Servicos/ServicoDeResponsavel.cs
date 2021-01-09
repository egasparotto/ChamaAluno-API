using ChamaAluno.Dominio.Cadastros.Alunos.Entidades;
using ChamaAluno.Dominio.Cadastros.Alunos.Repositorios;
using ChamaAluno.Dominio.Cadastros.Pessoas.Servicos;
using ChamaAluno.Dominio.Cadastros.Responsaveis.Entidades;
using ChamaAluno.Dominio.Cadastros.Responsaveis.Repositorios;

using EGF.Dominio.Contextos;

using System;
using System.Collections.Generic;
using System.Linq;

namespace ChamaAluno.Dominio.Cadastros.Responsaveis.Servicos
{
    public class ServicoDeResponsavel : ServicoDePessoa<Responsavel, IRepositorioDeResponsavel>, IServicoDeResponsavel
    {
        protected IRepositorioDeAlunoDoResponsavel RepositorioDeAlunoDoResponsavel { get; }

        public ServicoDeResponsavel(IRepositorioDeResponsavel repositorio, IContexto contextoDaAplicacao, IRepositorioDeAlunoDoResponsavel repositorioDeAlunoDoResponsavel) : base(repositorio, contextoDaAplicacao)
        {
            RepositorioDeAlunoDoResponsavel = repositorioDeAlunoDoResponsavel;
        }

        public IEnumerable<AlunoDoResponsavel> ObterAlunosAutorizados(int idDoResponsavel, DateTime data)
        {
            return RepositorioDeAlunoDoResponsavel.ObterAlunosAutorizados(idDoResponsavel, data).ToList().Where(x => PossuiPermissaoHoje(x, data));
        }


        private static bool PossuiPermissaoHoje(AlunoDoResponsavel alunoDoResponsavel, DateTime data)
        {
            if (alunoDoResponsavel != null)
            {
                switch (data.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        return alunoDoResponsavel.Domingo;
                    case DayOfWeek.Monday:
                        return alunoDoResponsavel.Segunda;
                    case DayOfWeek.Tuesday:
                        return alunoDoResponsavel.Terca;
                    case DayOfWeek.Wednesday:
                        return alunoDoResponsavel.Quarta;
                    case DayOfWeek.Thursday:
                        return alunoDoResponsavel.Quinta;
                    case DayOfWeek.Friday:
                        return alunoDoResponsavel.Sexta;
                    case DayOfWeek.Saturday:
                        return alunoDoResponsavel.Sabado;
                }
            }
            throw new Exception("Não foi possível verificar permissões do responsável");
        }
    }
}
