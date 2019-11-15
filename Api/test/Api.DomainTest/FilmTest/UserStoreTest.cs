using Api.Domain.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Api.DomainTest.FilmTest {
    public class UserStoreTest {
        [Fact]
        public void DevoAdicionarUsuario() {
            var userDto = new UserDto {
                CPF = "453.461.555.22",
                Nome = "Guilherme",
                Senha = "123456"
            };

            var userRepositoryMock = new Mock<IUserRepository>();

            var userStore = new UserStore(userRepositoryMock.Object);

            userStore.Add(userDto);

            userRepositoryMock.Verify(r => r.Add(It.IsAny<User>()));
        }
    }

    public class UserStore {
        private readonly IUserRepository _userRepository;
        public UserStore(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public void Add(UserDto userDto) {
            var user = new User(userDto.CPF, userDto.Nome, userDto.Senha);

            _userRepository.Add(user);
        }
    }

    public interface IUserRepository
    {
        void Add(User user);
    }

    public class UserDto {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
