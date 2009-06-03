using System;

namespace GrupoDeEstudos.Refatoracao.VideoLocadora
{
    public class Filme
    {
        private string titulo;
        private FilmeCodigoPreco codigoPreco;

        public string Titulo
        {
            get { return titulo; }
        }

        public FilmeCodigoPreco CodigoPreco
        {
            get { return codigoPreco; }
            set { codigoPreco = value; }
        }

        public Filme(string titulo, FilmeCodigoPreco codigoPreco)
        {
            this.titulo = titulo;
            this.codigoPreco = codigoPreco;
        }
    }
}
