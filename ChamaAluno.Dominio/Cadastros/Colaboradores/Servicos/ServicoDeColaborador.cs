using ChamaAluno.Dominio.Base.Excecoes;
using ChamaAluno.Dominio.Base.Utils;
using ChamaAluno.Dominio.Cadastros.Colaboradores.Entidades;
using ChamaAluno.Dominio.Cadastros.Colaboradores.Repositorios;
using ChamaAluno.Dominio.Cadastros.Pessoas.Servicos;

using EGF.Dominio.Contextos;

using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChamaAluno.Dominio.Cadastros.Colaboradores.Servicos
{
    public class ServicoDeColaborador : ServicoDePessoa<Colaborador, IRepositorioDeColaborador>, IServicoDeColaborador
    {
        public ServicoDeColaborador(IRepositorioDeColaborador repositorio, IContexto contextoDaAplicacao) : base(repositorio, contextoDaAplicacao)
        {
        }

        public override Colaborador Inserir(Colaborador entidade)
        {
            if (entidade != null)
            {
                if (!string.IsNullOrEmpty(entidade.Senha))
                {
                    entidade.Senha = Criptografia.Criptografa(entidade.Senha);
                }
            }
            return base.Inserir(entidade);
        }

        public override Colaborador Editar(Colaborador entidade)
        {
            return base.Editar(entidade);
        }

        public override void Remover(Colaborador entidade)
        {
            if (Repositorio.Buscar().Count() == 1)
            {
                throw new ErroDeValidacaoDeEntidade("Não é possivel excluir o último colaborador do sistema.");
            }
            base.Remover(entidade);
        }

        public override void Remover(IEnumerable<Colaborador> entidade)
        {
            if (Repositorio.Buscar().Count() == entidade.Count())
            {
                throw new ErroDeValidacaoDeEntidade("Não é possivel excluir o último colaborador do sistema.");
            }
            base.Remover(entidade);
        }

        public async Task<IdentityResult> CreateAsync(Colaborador user, CancellationToken cancellationToken)
        {
            try
            {
                await Repositorio.InserirAsync(user);
                return IdentityResult.Success;
            }
            catch (Exception e)
            {
                IdentityError error = new IdentityError
                {
                    Description = e.Message
                };
                return IdentityResult.Failed(error);
            }
        }

        public async Task<IdentityResult> DeleteAsync(Colaborador user, CancellationToken cancellationToken)
        {
            try
            {
                await Repositorio.RemoverAsync(user);
                return IdentityResult.Success;
            }
            catch (Exception e)
            {
                IdentityError error = new IdentityError
                {
                    Description = e.Message
                };
                return IdentityResult.Failed(error);
            }
        }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<Colaborador> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Email.ToUpper() == normalizedEmail);
            return retorno.FirstOrDefault();
        }

        public async Task<Colaborador> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == int.Parse(userId));
            return retorno.FirstOrDefault();
        }

        public async Task<Colaborador> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Email.ToUpper() == normalizedUserName);
            return retorno.FirstOrDefault();
        }

        public async Task<string> GetEmailAsync(Colaborador user, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == user.Id);
            return retorno.FirstOrDefault()?.Email;
        }

        public async Task<bool> GetEmailConfirmedAsync(Colaborador user, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == user.Id);
            var Colaborador = retorno.FirstOrDefault();
            if (Colaborador != null)
            {
                return Colaborador.EmailConfirmado;
            }
            else
            {
                return true;
            }
        }

        public async Task<string> GetNormalizedEmailAsync(Colaborador user, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == user.Id);
            return retorno.FirstOrDefault()?.Email?.ToUpper();
        }

        public async Task<string> GetNormalizedUserNameAsync(Colaborador user, CancellationToken cancellationToken)
        {
            return await GetNormalizedEmailAsync(user, cancellationToken);
        }

        public async Task<string> GetPasswordHashAsync(Colaborador user, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == user.Id);
            return retorno.FirstOrDefault()?.Senha;
        }

        public async Task<string> GetUserIdAsync(Colaborador user, CancellationToken cancellationToken)
        {
            var retorno = await Repositorio.BuscarAsync(x => x.Id == user.Id);
            return retorno.FirstOrDefault()?.Id.ToString();
        }

        public async Task<string> GetUserNameAsync(Colaborador user, CancellationToken cancellationToken)
        {
            return await GetEmailAsync(user, cancellationToken);
        }

        public async Task<bool> HasPasswordAsync(Colaborador user, CancellationToken cancellationToken)
        {
            var senha = await GetPasswordHashAsync(user, cancellationToken);
            return !string.IsNullOrEmpty(senha);
        }

        public Task SetEmailAsync(Colaborador user, string email, CancellationToken cancellationToken)
        {
            user.Email = email;
            return Task.FromResult((object)null);
        }

        public Task SetEmailConfirmedAsync(Colaborador user, bool confirmed, CancellationToken cancellationToken)
        {
            user.EmailConfirmado = confirmed;
            return Task.FromResult((object)null);
        }

        public Task SetNormalizedEmailAsync(Colaborador user, string normalizedEmail, CancellationToken cancellationToken)
        {
            user.Email = normalizedEmail;
            return Task.FromResult((object)null);
        }

        public Task SetNormalizedUserNameAsync(Colaborador user, string normalizedName, CancellationToken cancellationToken)
        {
            user.Email = normalizedName;
            return Task.FromResult((object)null);
        }

        public Task SetPasswordHashAsync(Colaborador user, string passwordHash, CancellationToken cancellationToken)
        {
            user.Senha = passwordHash;
            return Task.FromResult((object)null);
        }

        public Task SetUserNameAsync(Colaborador user, string userName, CancellationToken cancellationToken)
        {
            user.Email = userName;
            return Task.FromResult((object)null);
        }

        public async Task<IdentityResult> UpdateAsync(Colaborador user, CancellationToken cancellationToken)
        {
            try
            {
                await Repositorio.EditarAsync(user);
                return IdentityResult.Success;
            }
            catch (Exception e)
            {
                IdentityError error = new IdentityError
                {
                    Description = e.Message
                };
                return IdentityResult.Failed(error);
            }
        }

        public Task AddToRoleAsync(Colaborador user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(Colaborador user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<string>> GetRolesAsync(Colaborador user, CancellationToken cancellationToken)
        {
            var perfil = await Task.FromResult(user.Perfil.CodigoInterno);
            return new List<string>() { perfil };
        }

        public async Task<bool> IsInRoleAsync(Colaborador user, string roleName, CancellationToken cancellationToken)
        {
            return await Task.FromResult(user.Perfil.CodigoInterno == roleName);
        }

        public async Task<IList<Colaborador>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            var usuarios = await Repositorio.BuscarAsync(x => x.Perfil.CodigoInterno == roleName);
            return usuarios.ToList();
        }
    }
}
