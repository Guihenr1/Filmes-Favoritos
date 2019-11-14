using Api.DomainTest._Builder;
using Api.DomainTest._Util;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Api.DomainTest.UserTest {
    public class FilmUserTest {
        private readonly int _usuario_id;
        private readonly int _filme_id;
        public FilmUserTest() {
            _usuario_id = 1;
            _filme_id = 1;
        }
        [Fact]
        public void DevoCriarFilmeUsuario() {
            var FilmeUsuarioEsperado = new {
                Usuario_Id = _usuario_id,
                Filme_Id = _filme_id
            };

            var filmeUsuario = new FilmUser(FilmeUsuarioEsperado.Usuario_Id, FilmeUsuarioEsperado.Filme_Id);

            filmeUsuario.ToExpectedObject().ShouldMatch(filmeUsuario);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void UsuarioIdNaoDeveSerZeroOuNegativo(int usuarioId) {

            Assert.Throws<ArgumentException>(() =>
                                FilmUserBuilder.Novo().ComUserId(usuarioId).Build()).ComMensagem("Id do usuário inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void FilmeIdNaoDeveSerZeroOuNegativo(int filmeId) {

            Assert.Throws<ArgumentException>(() =>
                                FilmUserBuilder.Novo().ComFilmId(filmeId).Build()).ComMensagem("Id do filme inválido");
        }
    }

    public class FilmUser {
        public FilmUser(int usuario_Id, int filme_Id) {
            if (usuario_Id <= 0)
                throw new ArgumentException("Id do usuário inválido");

            if (filme_Id <= 0)
                throw new ArgumentException("Id do filme inválido");

            Usuario_Id = usuario_Id;
            Filme_Id = filme_Id;
        }

        public int Usuario_Id { get; private set; }
        public int Filme_Id { get; private set; }
    }
}
