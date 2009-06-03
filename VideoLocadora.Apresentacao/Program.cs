using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrupoDeEstudos.Refatoracao.VideoLocadora;

namespace VideoLocadora.Apresentacao
{
    class Program
    {
        static void Main(string[] args)
        {
            Filme filmeClubeDaLuta = new Filme("Clube da Luta", FilmeCodigoPreco.Normal);
            Filme filmeEraDoGelo = new Filme("Era do Gelo", FilmeCodigoPreco.Infantil);
            Filme filmeSeteVidas = new Filme("Sete vidas", FilmeCodigoPreco.Lancamento);
            Filme filmeWolverine = new Filme("Wolverine", FilmeCodigoPreco.Lancamento);

            Locacao locacaoClubeDaLuta = new Locacao(filmeClubeDaLuta, 4);
            Locacao locacaoEraDoGelo = new Locacao(filmeEraDoGelo, 4);
            Locacao locacaoSeteVidas = new Locacao(filmeSeteVidas, 4);
            Locacao locacaoWolverine = new Locacao(filmeWolverine, 4);

            Cliente cliente = new Cliente("Pedro Bonamides");
            cliente.AdicionarLocacao(locacaoClubeDaLuta);
            cliente.AdicionarLocacao(locacaoEraDoGelo);
            cliente.AdicionarLocacao(locacaoSeteVidas);
            cliente.AdicionarLocacao(locacaoWolverine);

            string conta = cliente.Conta();

            Console.WriteLine(conta);
            Console.ReadKey();
        }
    }
}
