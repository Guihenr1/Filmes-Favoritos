using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.User {
    public class FilmStore {
        private readonly IFilmRepository _filmRepository;
        public FilmStore(IFilmRepository filmRepository) {
            _filmRepository = filmRepository;
        }

        public void Add(FilmDto filmDto) {
            var film = new Film(filmDto.Filme_Id, filmDto.Titulo, filmDto.Nota, filmDto.Lancamento);

            _filmRepository.Add(film);
        }
    }
}
