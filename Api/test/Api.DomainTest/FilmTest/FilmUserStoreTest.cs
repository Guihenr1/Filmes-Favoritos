using Api.Domain.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Api.DomainTest.FilmTest {
    public class FilmUserStoreTest {
        [Fact]
        public void DevoAdicionarFilmeUsuario() {
            var filmUserDto = new FilmUserDto {
                Usuario = new User("1234", "Guilherme", "123456"),
                Filme = new Film(1,"AAA",5,"209-01-01")
            };

            var filmUserRepositoryMock = new Mock<IFilmUserRepository>();

            var filmUserStore = new FilmUserStore(filmUserRepositoryMock.Object);

            filmUserStore.Add(filmUserDto);

            filmUserRepositoryMock.Verify(r => r.Add(It.IsAny<FilmUser>()));
        }
    }

    public interface IFilmUserRepository {
        void Add(FilmUser filmUserDto);
    }

    public class FilmUserStore {
        private readonly IFilmUserRepository _filmUserRepository;
        public FilmUserStore(IFilmUserRepository filmUserRepository) {
            _filmUserRepository = filmUserRepository;
        }

        public void Add(FilmUserDto filmUserDto) {
            var filmUser = new FilmUser(filmUserDto.Usuario, filmUserDto.Filme);

            _filmUserRepository.Add(filmUser);
        }
    }

    public class FilmUserDto {
        public User Usuario { get; set; }
        public Film Filme { get; set; }
    }
}
