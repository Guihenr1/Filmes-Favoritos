using Api.Domain.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Api.DomainTest.FilmTest {
    public class FilmStoreTest {
        [Fact]
        public void DevoAdicionarFilme() {
            var filmDto = new FilmDto {
                Filme_Id = 1,
                Titulo = "AAA",
                Nota = 5,
                Lancamento = "2019-01-01"
            };

            var filmRepositoryMock = new Mock<IFilmRepository>();

            var filmStore = new FilmStore(filmRepositoryMock.Object);

            filmStore.Add(filmDto);

            filmRepositoryMock.Verify(r => r.Add(It.IsAny<Film>()));
        }
    }
    public interface IFilmRepository {
        void Add(Film film);
    }
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
    public class FilmDto {
        public int Filme_Id { get; set; }
        public string Titulo { get; set; }
        public double Nota { get; set; }
        public string Lancamento { get; set; }
    }
}
