using System;
using System.Collections.Generic;

namespace GrupoDeEstudos.Refatoracao.VideoLocadora
{
    public class Cliente
    {
        private string nome;
        private List<Locacao> locacoes = new List<Locacao>();

        public string Nome
        {
            get { return nome; }
        }

        public Cliente(string nome)
        {
            this.nome = nome;
        }

        public void AdicionarLocacao(Locacao locacao)
        {
            this.locacoes.Add(locacao);
        }

        public string Conta()
        {
            double quantiaTotal = 0;
            int pontosLocadorFrequente = 0;
            string resultado = "Registro de locação de " + this.Nome + "\n";

            foreach (Locacao cada in this.locacoes)
            {
                double estaQuantia = 0;

                //Determinar quantias para cada linha.
                switch (cada.Filme.CodigoPreco)
                {
                    case FilmeCodigoPreco.Normal:
                        estaQuantia += 2;

                        if (cada.DiasAlugados > 2)
                        {
                            estaQuantia += (cada.DiasAlugados - 2) * 1.5;
                        }
                        break;

                    case FilmeCodigoPreco.Lancamento:
                        estaQuantia += cada.DiasAlugados * 3;
                        break;

                    case FilmeCodigoPreco.Infantil:
                        estaQuantia += 1.5;

                        if (cada.DiasAlugados > 3)
                        {
                            estaQuantia += (cada.DiasAlugados - 3) * 1.5;
                        }
                        break;
                }

                //Adicionar pontos do locador frequente.
                pontosLocadorFrequente++;

                //Adicionar bônus para uma locação de lançamentos por dois dias.
                if (cada.Filme.CodigoPreco == FilmeCodigoPreco.Lancamento && cada.DiasAlugados > 1)
                {
                    pontosLocadorFrequente++;
                }

                //Mostrar valores para esta locação.
                resultado += "\t" + cada.Filme.Titulo + "\t" + estaQuantia.ToString() + "\n";

                quantiaTotal += estaQuantia;
            }

            //Adicionar linhas de rodapé.
            resultado += "O valor devido é " + quantiaTotal.ToString() + ".\n";
            resultado += "Você ganhou " + pontosLocadorFrequente.ToString() + " pontos de locador frequente.";

            return resultado;
        }
    }
}
