using ChamaAluno.Dominio.Base.Atributos.Validadores;
using ChamaAluno.Dominio.Base.Entidades;
using ChamaAluno.Dominio.Cadastros.Pessoas.Validadores;

using System;

namespace ChamaAluno.Dominio.Cadastros.Pessoas.Entidades
{
    public abstract class Pessoa : EntidadeDoChamaAluno
    {
        [Requerido]
        public string Nome { get; set; }

        [ValidadorDeCPFOuRGDaPessoa]
        [ValidadorDeCPF]
        public string CPF { get; set; }

        public string RG { get; set; }

        public byte[] Foto { get; set; }

        public string FotoBase64()
        {
            if (Foto != null && Foto.Length > 0)
            {
                return Convert.ToBase64String(Foto);
            }
            else
            {
                return null;
            }
        }

        public void AtualizaFoto(string fotoBase64)
        {
            if (!string.IsNullOrEmpty(fotoBase64))
            {
                Foto = Convert.FromBase64String(fotoBase64);
            }
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
