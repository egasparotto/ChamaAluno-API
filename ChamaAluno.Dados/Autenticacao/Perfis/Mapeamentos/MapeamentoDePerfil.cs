using EGF.Dominio.Autenticacao.Perfis.Entidades;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamaAluno.Dados.Autenticacao.Perfis.Mapeamentos
{
    class MapeamentoDePerfil : EGF.Dados.EFCore.Autenticacao.Perfis.Mapeamentos.MapeamentoDePerfil
    {
        protected override void Mapear(EntityTypeBuilder<Perfil> builder)
        {
            base.Mapear(builder);
            builder.HasData(new Perfil()
            {
                CodigoInterno = "0001",
                Descricao = "Administrador",
                Id = 1
            });
        }
    }
}
