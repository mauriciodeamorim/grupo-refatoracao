using System;

namespace GrupoDeEstudos.Refatoracao.VideoLocadora
{
    public class Locacao
    {
        private Filme filme;
        private int diasAlugados;

        public Filme Filme
        {
            get { return filme; }
            set { filme = value; }
        }

        public int DiasAlugados
        {
            get { return diasAlugados; }
            set { diasAlugados = value; }
        }

        public Locacao(Filme filme, int diasAlugados)
        {
            this.filme = filme;
            this.diasAlugados = diasAlugados;
        }
    }
}
