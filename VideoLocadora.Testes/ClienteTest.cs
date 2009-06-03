using System;
using System.Collections.Generic;
using GrupoDeEstudos.Refatoracao.VideoLocadora;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VideoLocadora.Testes
{
    [TestClass]
    public class ClienteTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void Exibe_Dados_Da_Conta_Do_Cliente()
        {
            Cliente cliente = new Cliente("Pedro Bonamides");
            this.AdicionarLocacoes(cliente);
            
            string contaEsperada = this.CriarContaEsperada(cliente);
            string contaAtual = cliente.Conta();

            Assert.AreEqual<string>(contaEsperada, contaAtual);
        }

        private void AdicionarLocacoes(Cliente cliente)
        {
            foreach (var locacao in CriarLocacoes(CriarFilmes()))
            {
                cliente.AdicionarLocacao(locacao);
            }
        }

        private IList<Filme> CriarFilmes()
        {
            List<Filme> filmes = new List<Filme>(4);
            filmes.Add(new Filme("Clube da Luta", FilmeCodigoPreco.Normal));
            filmes.Add(new Filme("Era do Gelo", FilmeCodigoPreco.Infantil));
            filmes.Add(new Filme("Sete vidas", FilmeCodigoPreco.Lancamento));
            filmes.Add(new Filme("Wolverine", FilmeCodigoPreco.Lancamento));

            return filmes;
        }

        private IList<Locacao> CriarLocacoes(IList<Filme> filmes)
        {
            List<Locacao> locacoes = new List<Locacao>(filmes.Count);

            foreach (var filme in filmes)
            {
                locacoes.Add(new Locacao(filme, 4));
            }

            return locacoes;
        }

        private string CriarContaEsperada(Cliente cliente)
        {
            string conta = "Registro de locação de " + cliente.Nome + "\n";
            conta += "\tClube da Luta\t5\n";
            conta += "\tEra do Gelo\t3\n";
            conta += "\tSete vidas\t12\n";
            conta += "\tWolverine\t12\n";
            conta += "O valor devido é 32.\n";
            conta += "Você ganhou 6 pontos de locador frequente.";

            return conta;
        }
    }
}
