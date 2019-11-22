using Api.Domain.User;
using Bogus;
using Moq;
using Xunit;

namespace Api.DomainTest.FilmTest {
    public class FilmUserStoreTest {
        private readonly FilmUserDto _filmUserDto;
        private readonly FilmUserStore _filmUserStore;
        private readonly Mock<IFilmUserRepository> _filmUserRepository;
        public FilmUserStoreTest() {
            var fake = new Faker();

            _filmUserDto = new FilmUserDto {
                UsuarioId = 1,
                FilmeId = 1
            };

            _filmUserRepository = new Mock<IFilmUserRepository>();

            _filmUserStore = new FilmUserStore(_filmUserRepository.Object);
        }
        [Fact]
        public void DevoAdicionarFilmeUsuario() {
            var filmUserDto = new FilmUserDto {
                UsuarioId = 1,
                FilmeId = 1
            };

            var filmUserRepositoryMock = new Mock<IFilmUserRepository>();

            var filmUserStore = new FilmUserStore(filmUserRepositoryMock.Object);

            filmUserStore.Add(filmUserDto);

            filmUserRepositoryMock.Verify(r => r.Add(It.IsAny<FilmUser>()));
        }
    }
}
