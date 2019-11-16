using Api.Domain.User;
using Api.DomainTest._Builder;
using Api.DomainTest._Util;
using Bogus;
using ExpectedObjects;
using System;
using Xunit;

namespace Api.DomainTest.FilmTest {
    public class FilmTest {
        private readonly int _filme_id;
        private readonly string _titulo;
        private readonly double _nota;
        private readonly string _lancamento;
        public FilmTest() {
            var fake = new Faker();

            _filme_id = fake.Random.Int(1, 9999);
            _titulo = fake.Random.Word();
            _nota = fake.Random.Double(0.1, 5);
            _lancamento = fake.Random.Word();
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
}
