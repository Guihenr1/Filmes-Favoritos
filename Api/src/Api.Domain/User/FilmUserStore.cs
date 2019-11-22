using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.User {
    public class FilmUserStore {
        private readonly IFilmUserRepository _filmUserRepository;
        public FilmUserStore(IFilmUserRepository filmUserRepository) {
            _filmUserRepository = filmUserRepository;
        }

        public void Add(FilmUserDto filmUserDto) {
            var filmUser = new FilmUser(filmUserDto.UsuarioId, filmUserDto.FilmeId);

            _filmUserRepository.Add(filmUser);
        }
    }
}
