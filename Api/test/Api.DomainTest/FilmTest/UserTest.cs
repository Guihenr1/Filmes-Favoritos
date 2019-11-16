using Api.Domain.User;
using Api.DomainTest._Builder;
using Api.DomainTest._Util;
using Bogus;
using ExpectedObjects;
using System;
using Xunit;

namespace Api.DomainTest.FilmTest {
    public class UserTest {
        private readonly string _cpf;
        private readonly string _nome;
        private readonly string _senha;
        public UserTest() {
            var fake = new Faker();

            _cpf = fake.Random.Word();
            _nome = fake.Random.Word();
            _senha = fake.Random.Word();
        }
        [Fact]
        public void DevoCriarUsuario() {
            var usuarioEsperado = new {
                CPF = _cpf,
                Nome = _nome,
                Senha = _senha
            };

            var usuario = new User(usuarioEsperado.CPF, usuarioEsperado.Nome, usuarioEsperado.Senha);

            usuarioEsperado.ToExpectedObject().ShouldMatch(usuario);
        }

        [Theory]
        [InlineData("")]

        [InlineData(null)]
        public void CPFNaoDeveSerVazioOuNulo(string cpf) {

            Assert.Throws<ArgumentException>(() =>
                                    UserBuilder.Novo().ComCpf(cpf).Build()).ComMensagem("Cpf inválido");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NomeNaoDeveSerVazioOuNulo(string nome) {

            Assert.Throws<ArgumentException>(() =>
                                        UserBuilder.Novo().ComNome(nome).Build()).ComMensagem("Nome inválido");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void SenhaNaoDeveSerNulaOuVazia(string senha) {

            Assert.Throws<ArgumentException>(() =>
                                UserBuilder.Novo().ComSenha(senha).Build()).ComMensagem("Senha inválida");
        }
    }    
}
