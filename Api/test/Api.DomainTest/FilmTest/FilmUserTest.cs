using Api.Domain.User;
using Api.DomainTest._Builder;
using Api.DomainTest._Util;
using Bogus;
using ExpectedObjects;
using System;
using Xunit;

namespace Api.DomainTest.FilmTest {
    public class FilmUserTest {
        private readonly User _usuario;
        private readonly Film _filme;
        public FilmUserTest() {
            var fake = new Faker();

            _usuario = new User(fake.Random.Word(), fake.Random.Word(), fake.Random.Word());
            _filme = new Film(fake.Random.Int(1, 9999)
                                , fake.Random.Word()
                                , fake.Random.Double(0.1, 5)
                                , fake.Random.Word());
        }
        [Fact]
        public void DevoCriarFilmeUsuario() {
            var FilmeUsuarioEsperado = new {
                Usuario = _usuario,
                Filme = _filme
            };

            var filmeUsuario = new FilmUser(FilmeUsuarioEsperado.Usuario, FilmeUsuarioEsperado.Filme);

            filmeUsuario.ToExpectedObject().ShouldMatch(filmeUsuario);
        }

        [Theory]
        [InlineData(null)]
        public void UserNaoPodeSerNulo(User user) {

            Assert.Throws<ArgumentException>(() =>
                                FilmUserBuilder.Novo().ComUserId(user).Build()).ComMensagem("Usuário inválido");
        }

        [Theory]
        [InlineData(null)]
        public void FilmNaoPodeSerNulo(Film film) {

            Assert.Throws<ArgumentException>(() =>
                                FilmUserBuilder.Novo().ComFilmId(film).Build()).ComMensagem("Filme inválido");
        }
    }    
}
