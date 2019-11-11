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
    }

    public class FilmUser {
        public int Usuario_Id { get; private set; }
        public int Filme_Id { get; private set; }

        public FilmUser(int usuario_Id, int filme_Id) {
            Usuario_Id = usuario_Id;
            Filme_Id = filme_Id;
        }
    }
}
