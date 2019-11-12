using Api.DomainTest._Util;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Api.DomainTest.UserTest {
    public class FilmUserTest {
        [Fact]
        public void DevoCriarFilmeUsuario() {
            var FilmeUsuarioEsperado = new {
                Usuario_Id = 1,
                Filme_Id = 1
            };

            var filmeUsuario = new FilmUser(FilmeUsuarioEsperado.Usuario_Id, FilmeUsuarioEsperado.Filme_Id);

            filmeUsuario.ToExpectedObject().ShouldMatch(filmeUsuario);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void UsuarioIdNaoDeveSerZeroOuNegativo(int usuarioId) {
            var FilmeUsuarioEsperado = new {
                Filme_Id = 1
            };

            Assert.Throws<ArgumentException>(() =>
                                new FilmUser(usuarioId, FilmeUsuarioEsperado.Filme_Id)).ComMensagem("Id do usuário inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void FilmeIdNaoDeveSerZeroOuNegativo(int filmeId) {
            var FilmeUsuarioEsperado = new {
                Usuario_Id = 1
            };

            Assert.Throws<ArgumentException>(() =>
                                new FilmUser(FilmeUsuarioEsperado.Usuario_Id, filmeId)).ComMensagem("Id do filme inválido");
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
