using Api.Domain.User;

namespace Api.DomainTest._Builder {
    public class FilmUserBuilder {
        private int _usuario = 1;
        private int _filme = 1;

        public static FilmUserBuilder Novo() {
            return new FilmUserBuilder();
        }

        public FilmUserBuilder ComUserId(int usuarioId) {
            _usuario = usuarioId;
            return this;
        }

        public FilmUserBuilder ComFilmId(int filmeId) {
            _filme = filmeId;
            return this;
        }

        public FilmUser Build() {
            return new FilmUser(_usuario, _filme);
        }
    }
}
