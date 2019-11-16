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
                Usuario = new User(fake.Random.Word()
                                    , fake.Random.Word()
                                    , fake.Random.Word()),
                Filme = new Film(fake.Random.Int(1, 9999)
                                    , fake.Random.Word()
                                    , fake.Random.Double(0.1, 5)
                                    , fake.Random.Word())
            };

            _filmUserRepository = new Mock<IFilmUserRepository>();

            _filmUserStore = new FilmUserStore(_filmUserRepository.Object);
        }
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
}
