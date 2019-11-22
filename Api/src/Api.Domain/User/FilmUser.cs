using Api.Domain._Base;
using System;

namespace Api.Domain.User {
    public class FilmUser : Entity {
        public FilmUser(int usuarioId, int filmeId) {
            if (usuarioId == 0)
                throw new ArgumentException("Usuário inválido");

            if (filmeId == 0)
                throw new ArgumentException("Filme inválido");

            UsuarioId = usuarioId;
            FilmeId = filmeId;
        }

        public int UsuarioId { get; private set; }
        public User Usuario { get; private set; }
        public int FilmeId { get; private set; }
        public Film Filme { get; private set; }
    }
}
