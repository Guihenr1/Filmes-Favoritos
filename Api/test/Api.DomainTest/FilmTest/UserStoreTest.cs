using Api.Domain.User;
using Api.DomainTest._Builder;
using Api.DomainTest._Util;
using Bogus;
using Moq;
using System;
using Xunit;

namespace Api.DomainTest.FilmTest {
    public class UserStoreTest {
        private readonly UserDto _userDto;
        private readonly UserStore _userStore;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        public UserStoreTest() {
            var fake = new Faker();

            _userDto = new UserDto {
                CPF = fake.Random.Word(),
                Nome = fake.Random.Word(),
                Senha = fake.Random.Word()
            };

            _userRepositoryMock = new Mock<IUserRepository>();

            _userStore = new UserStore(_userRepositoryMock.Object);
        }
        [Fact]
        public void DevoAdicionarUsuario() {

            _userStore.Add(_userDto);

            _userRepositoryMock.Verify(r => r.Add(It.Is<User>(
                c => c.Nome == _userDto.Nome &&
                c.CPF == _userDto.CPF
            )));
        }
        [Fact]
        public void NaoDevoAdicionarUsuarioComCPFJaCadastrado() {
            var userAlreadySave = UserBuilder.Novo().ComCpf(_userDto.CPF).Build();
            _userRepositoryMock.Setup(r => r.getCpf(_userDto.CPF)).Returns(userAlreadySave);

            Assert.Throws<ArgumentException>(() => _userStore.Add(_userDto))
                .ComMensagem(Resource.UsuarioJaCadastrado);
        }

        [Fact]
        public void DevoAlterarDadosDoUsuario() {
            _userDto.CPF = "000.000.000-00";
            var user = UserBuilder.Novo().Build();
            _userRepositoryMock.Setup(r => r.getCpf(_userDto.CPF)).Returns(user);

            _userStore.Update(_userDto);
            Assert.Equal(_userDto.CPF, user.CPF);
            Assert.Equal(_userDto.Nome, user.Nome);
            Assert.Equal(_userDto.Senha, user.Senha);
        }
    }    
}
