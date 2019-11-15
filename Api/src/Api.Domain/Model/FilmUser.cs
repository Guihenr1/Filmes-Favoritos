using System;

namespace Api.Domain.Model {
    public class FilmUser {
        public FilmUser(User usuario, Film filme) {
            if (usuario == null)
                throw new ArgumentException("Usuário inválido");

            if (filme == null)
                throw new ArgumentException("Filme inválido");

            Usuario = usuario;
            Filme = filme;
        }

        public User Usuario { get; private set; }
        public Film Filme { get; private set; }
    }
}
