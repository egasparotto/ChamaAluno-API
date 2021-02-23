using ChamaAluno.DTOs.Administracao.Licencas;

using EGF.Licenciamento.Core.Licencas.Gerenciadores;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;

namespace ChamaAluno.WebAPI.Controllers.Administracao.Licencas
{
    [AllowAnonymous]
    [ApiController]
    [Route("API/Administracao/[controller]")]
    public class LicenciamentoController
    {
        private readonly IGerenciadorDeLicenca _gerenciadorDeLicenca;

        public LicenciamentoController(IGerenciadorDeLicenca gerenciadorDeLicenca)
        {
            _gerenciadorDeLicenca = gerenciadorDeLicenca;
        }

        [HttpPost("Ativar")]
        public DTODeLicencaAtiva AtivarLicenca(DTODeAtivacaoDeLicenca dto)
        {
            if (_gerenciadorDeLicenca.LicencaExiste())
            {
                throw new Exception("Produto já ativo.");
            }
            if (string.IsNullOrEmpty(dto?.Chave))
            {
                throw new Exception("Licença Inválida.");
            }
            _gerenciadorDeLicenca.AtivarLicenca(dto.Chave);
            return new DTODeLicencaAtiva() { Ativo = true };
        }

        [HttpGet("Ativo")]
        public DTODeLicencaAtiva Ativo()
        {
            if (_gerenciadorDeLicenca.LicencaExiste())
            {
                return new DTODeLicencaAtiva() { Ativo = true };
            }
            return new DTODeLicencaAtiva() { Ativo = false };
        }
    }
}
