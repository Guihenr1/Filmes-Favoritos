using Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.DomainTest._Builder {
    public class FilmUserBuilder {
        private User _usuario = new User("1234", "Guilherme", "123456");
        private Film _filme = new Film(1, "AAA", 5, "209-01-01");

        public static FilmUserBuilder Novo() {
            return new FilmUserBuilder();
        }

        public FilmUserBuilder ComUserId(User usuario) {
            _usuario = usuario;
            return this;
        }

        public FilmUserBuilder ComFilmId(Film filme) {
            _filme = filme;
            return this;
        }

        public FilmUser Build() {
            return new FilmUser(_usuario, _filme);
        }
    }
}
