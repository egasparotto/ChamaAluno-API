using ChamaAluno.Dominio.Base.Interfaces;
using ChamaAluno.Dominio.Cadastros.Colaboradores.Entidades;

using Microsoft.AspNetCore.Identity;

namespace ChamaAluno.Dominio.Cadastros.Colaboradores.Servicos
{
    public interface IServicoDeColaborador : IServicoComListagem<Colaborador>, IUserStore<Colaborador>, IUserPasswordStore<Colaborador>, IUserEmailStore<Colaborador>, IUserRoleStore<Colaborador>
    {
    }
}
