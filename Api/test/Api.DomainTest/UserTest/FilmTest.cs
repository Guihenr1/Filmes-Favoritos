using Api.DomainTest._Util;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Api.DomainTest.UserTest {
    public class FilmTest {
        [Fact]
        public void DevoCriarFilme() {
            var filmeEsperado = new {
                Filme_Id = (int)1,
                Titulo = "Os Vingadores",
                Nota = (double)4.75,
                Lancamento = "2019-01-01"
            };

            var filme = new Film(filmeEsperado.Filme_Id, filmeEsperado.Titulo, filmeEsperado.Nota, filmeEsperado.Lancamento);

            filmeEsperado.ToExpectedObject().ShouldMatch(filme);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void FilmeIdNaoDeveSerZeroOuNegativo(int filmeId) {
            var filmeEsperado = new {
                Titulo = "Os Vingadores",
                Nota = (double)4.75,
                Lancamento = "2019-01-01"
            };

            var messagem = Assert.Throws<ArgumentException>(() =>
                                new Film(filmeId, filmeEsperado.Titulo, filmeEsperado.Nota, filmeEsperado.Lancamento)).Message;
            Assert.Equal("Id do filme inválido", messagem);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void TituloNaoDeveSerVazioOuNulo(string titulo) {
            var filmeEsperado = new {
                Filme_Id = (int)1,
                Nota = (double)4.75,
                Lancamento = "2019-01-01"
            };

            Assert.Throws<ArgumentException>(() =>
                                new Film(filmeEsperado.Filme_Id, titulo, filmeEsperado.Nota, filmeEsperado.Lancamento)).ComMensagem("Título do filme inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(6)]
        public void NotaNaoDeveSerZeroOuNegativoOuMaiorQueCinco(int nota) {
            var filmeEsperado = new {
                Filme_Id = (int)1,
                Titulo = "Os Vingadores",
                Lancamento = "2019-01-01"
            };

            Assert.Throws<ArgumentException>(() =>
                                new Film(filmeEsperado.Filme_Id, filmeEsperado.Titulo, nota, filmeEsperado.Lancamento)).ComMensagem("Nota do filme inválida");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void LancamentoNaoDeveSerVazioOuNuloOuNaoData(string lancamento) {
            var filmeEsperado = new {
                Filme_Id = (int)1,
                Titulo = "Os Vingadores",
                Nota = (double)4.75
            };

            Assert.Throws<ArgumentException>(() =>
                                new Film(filmeEsperado.Filme_Id, filmeEsperado.Titulo, filmeEsperado.Nota, lancamento)).ComMensagem("Lancamento do filme inválido");
        }
    }

    public class Film {
        public Film(int filme_Id, string titulo, double nota, string lancamento) {
            if (filme_Id <= 0)
                throw new ArgumentException("Id do filme inválido");
            
            if (string.IsNullOrEmpty(titulo))
                throw new ArgumentException("Título do filme inválido");

            if (nota <= 0 || nota > 5)
                throw new ArgumentException("Nota do filme inválida");

            if (string.IsNullOrEmpty(lancamento))
                throw new ArgumentException("Lancamento do filme inválido");

            Filme_Id = filme_Id;
            Titulo = titulo;
            Nota = nota;
            Lancamento = lancamento;
        }

        public int Filme_Id { get; private set; }
        public string Titulo { get; private set; }
        public double Nota { get; private set; }
        public string Lancamento { get; private set; }
    }
}
