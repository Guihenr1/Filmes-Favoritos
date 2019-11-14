using Api.DomainTest._Builder;
using Api.DomainTest._Util;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Api.DomainTest.UserTest {
    public class UserTest {
        private readonly string _cpf;
        private readonly string _nome;
        private readonly string _senha;
        public UserTest() {
            _cpf = "453.461.528-06";
            _nome = "Guilherme";
            _senha = "123456";
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

    public class User {
        public User(string cpf, string nome, string senha) {
            if (string.IsNullOrEmpty(cpf))
                throw new ArgumentException("Cpf inválido");

            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome inválido");

            if (string.IsNullOrEmpty(senha))
                throw new ArgumentException("Senha inválida");

            CPF = cpf;
            Nome = nome;
            Senha = senha;
        }

        public string CPF { get; private set; }
        public string Nome { get; private set; }
        public string Senha { get; private set; }
    }
}
