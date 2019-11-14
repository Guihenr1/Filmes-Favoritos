using Api.DomainTest.UserTest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.DomainTest._Builder {
    public class FilmUserBuilder {
        private int _usuario_id = 1;
        private int _filme_id = 1;

        public static FilmUserBuilder Novo() {
            return new FilmUserBuilder();
        }

        public FilmUserBuilder ComUserId(int usuario_id) {
            _usuario_id = usuario_id;
            return this;
        }

        public FilmUserBuilder ComFilmId(int filme_id) {
            _filme_id = filme_id;
            return this;
        }

        public FilmUser Build() {
            return new FilmUser(_usuario_id, _filme_id);
        }
    }
}
