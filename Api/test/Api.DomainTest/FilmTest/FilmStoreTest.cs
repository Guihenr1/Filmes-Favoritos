using Api.Domain.User;
using Bogus;
using Moq;
using Xunit;

namespace Api.DomainTest.FilmTest {
    public class FilmStoreTest {
        private readonly FilmDto _filmDto;
        private readonly FilmStore _filmStore;
        private readonly Mock<IFilmRepository> _filmRepositoryMock;
        public FilmStoreTest() {
            var fake = new Faker();

            _filmDto = new FilmDto() {
                Filme_Id = fake.Random.Int(1, 9999),
                Titulo = fake.Random.Word(),
                Nota = fake.Random.Double(0.1, 5),
                Lancamento = fake.Random.Word()
            };

            _filmRepositoryMock = new Mock<IFilmRepository>();

            _filmStore = new FilmStore(_filmRepositoryMock.Object);
        }
        [Fact]
        public void DevoAdicionarFilme() {
            _filmStore.Add(_filmDto);

            _filmRepositoryMock.Verify(r => r.Add(It.Is<Film>(
                c => c.Titulo == c.Titulo    
            )));
        }
    }
}
