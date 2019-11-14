using Api.DomainTest._Builder;
using Api.DomainTest._Util;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Api.DomainTest.UserTest {
    public class FilmTest {
        private readonly int _filme_id;
        private readonly string _titulo;
        private readonly double _nota;
        private readonly string _lancamento;
        public FilmTest() {
            _filme_id = 1;
            _titulo = "Os Vingadores";
            _nota = 4.75;
            _lancamento = "2019-01-01";
        }
        [Fact]
        public void DevoCriarFilme() {
            var filmeEsperado = new {
                Filme_Id = _filme_id,
                Titulo = _titulo,
                Nota = _nota,
                Lancamento = _lancamento
            };

            var filme = new Film(filmeEsperado.Filme_Id, filmeEsperado.Titulo, filmeEsperado.Nota, filmeEsperado.Lancamento);

            filmeEsperado.ToExpectedObject().ShouldMatch(filme);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void FilmeIdNaoDeveSerZeroOuNegativo(int filmeId) {

            var messagem = Assert.Throws<ArgumentException>(() =>
                                FilmBuilder.Novo().ComFilmeId(filmeId).Build()).Message;
            Assert.Equal("Id do filme inválido", messagem);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void TituloNaoDeveSerVazioOuNulo(string titulo) {

            Assert.Throws<ArgumentException>(() =>
                                FilmBuilder.Novo().ComTitulo(titulo).Build()).ComMensagem("Título do filme inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(6)]
        public void NotaNaoDeveSerZeroOuNegativoOuMaiorQueCinco(int nota) {
            var filmeEsperado = new {
                Filme_Id = _filme_id,
                Titulo = _titulo,
                Lancamento = _lancamento
            };

            Assert.Throws<ArgumentException>(() =>
                                FilmBuilder.Novo().ComNota(nota).Build()).ComMensagem("Nota do filme inválida");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void LancamentoNaoDeveSerVazioOuNuloOuNaoData(string lancamento) {
            var filmeEsperado = new {
                Filme_Id = _filme_id,
                Titulo = _titulo,
                Nota = _nota
            };

            Assert.Throws<ArgumentException>(() =>
                                FilmBuilder.Novo().ComLancamento(lancamento).Build()).ComMensagem("Lancamento do filme inválido");
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
