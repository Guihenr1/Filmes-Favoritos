using Api.Domain.User;
using Api.DomainTest._Builder;
using Api.DomainTest._Util;
using Bogus;
using ExpectedObjects;
using System;
using Xunit;

namespace Api.DomainTest.FilmTest {
    public class FilmUserTest {
        private readonly int _usuarioId;
        private readonly int _filmeId;
        public FilmUserTest() {
            var fake = new Faker();

            _usuarioId = 1;
            _filmeId = 1;
        }
        [Fact]
        public void DevoCriarFilmeUsuario() {
            var FilmeUsuarioEsperado = new {
                Usuario = _usuarioId,
                Filme = _filmeId
            };

            var filmeUsuario = new FilmUser(FilmeUsuarioEsperado.Usuario, FilmeUsuarioEsperado.Filme);

            filmeUsuario.ToExpectedObject().ShouldMatch(filmeUsuario);
        }

        [Theory]
        [InlineData(null)]
        public void UserNaoPodeSerNulo(int user) {

            Assert.Throws<ArgumentException>(() =>
                                FilmUserBuilder.Novo().ComUserId(user).Build()).ComMensagem("Usuário inválido");
        }

        [Theory]
        [InlineData(null)]
        public void FilmNaoPodeSerNulo(int film) {

            Assert.Throws<ArgumentException>(() =>
                                FilmUserBuilder.Novo().ComFilmId(film).Build()).ComMensagem("Filme inválido");
        }
    }    
}
