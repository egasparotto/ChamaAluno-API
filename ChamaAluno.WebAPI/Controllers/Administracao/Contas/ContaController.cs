using AutoMapper;

using ChamaAluno.Dominio.Cadastros.Colaboradores.Entidades;
using ChamaAluno.Dominio.Cadastros.Colaboradores.Servicos;
using ChamaAluno.DTOs.Administracao.Contas;
using ChamaAluno.DTOs.Cadastros.Colaboradores;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChamaAluno.WebAPI.Controllers.Administracao.Conta
{
    [ApiController]
    [Route("API/Administracao/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Colaborador> _userManager;
        private readonly SignInManager<Colaborador> _signInManager;
        private readonly IMapper _mapper;
        private readonly IServicoDeColaborador _servicoDeUsuario;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContaController(IConfiguration configuration, UserManager<Colaborador> userManager, SignInManager<Colaborador> signInManager, IMapper mapper, IServicoDeColaborador servicoDeUsuario, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
            _servicoDeUsuario = servicoDeUsuario;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpGet("UsuarioLogado")]
        public DTODeColaborador UsuarioLogado()
        {
            var strIdDoUsuario = _httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value;

            if (!string.IsNullOrEmpty(strIdDoUsuario))
            {
                var id = int.Parse(strIdDoUsuario);

                var entidade = _servicoDeUsuario.ObterPorID(id);

                var dto = _mapper.Map<DTODeColaborador>(entidade);

                return dto;

            }

            throw new Exception("Erro ao localizar usuário.");
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<DTODeRespostaDeLogin> Login(DTODeLogin dto)
        {
            var colaborador = await _userManager.FindByEmailAsync(dto.Email);
            if (colaborador != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(colaborador, dto.Senha, false);

                if (result.Succeeded)
                {
                    var colaboradorPesquisado = _servicoDeUsuario.Buscar(x => x.Email.ToUpper() == dto.Email.ToUpper()).FirstOrDefault();

                    var dtoParaRetorno = _mapper.Map<DTODeLogin>(colaboradorPesquisado);

                    return new DTODeRespostaDeLogin
                    {
                        Token = await GenerateJwt(colaboradorPesquisado),
                        Login = dtoParaRetorno
                    };
                }
            }
            throw new Exception("Usuário ou senha inválidos.");
        }


        private async Task<string> GenerateJwt(Colaborador colaborador)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, colaborador.Id.ToString()),
                new Claim(ClaimTypes.Name, colaborador.Nome),
                new Claim(ClaimTypes.Email, colaborador.Email),
                new Claim("host", _httpContextAccessor.HttpContext?.Request?.Host.Host)
            };

            var roles = await _userManager.GetRolesAsync(colaborador);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
