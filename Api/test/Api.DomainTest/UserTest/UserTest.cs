using Api.DomainTest._Util;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Api.DomainTest.UserTest {
    public class UserTest {
        [Fact]
        public void DevoCriarUsuario() {
            var usuarioEsperado = new {
                CPF = "453.461.528-06",
                Nome = "Guilherme",
                Senha = "123456"
            };

            var usuario = new User(usuarioEsperado.CPF, usuarioEsperado.Nome, usuarioEsperado.Senha);

            usuarioEsperado.ToExpectedObject().ShouldMatch(usuario);
        }

        [Theory]
        [InlineData("")]

        [InlineData(null)]
        public void CPFNaoDeveSerVazioOuNulo(string cpf) {
            var usuarioEsperado = new {
                Nome = "Guilherme",
                Senha = "123456"
            };

            Assert.Throws<ArgumentException>(() => 
                                    new User(cpf, usuarioEsperado.Nome, usuarioEsperado.Senha)).ComMensagem("Cpf inválido");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NomeNaoDeveSerVazioOuNulo(string nome) {
            var usuarioEsperado = new {
                CPF = "453.461.528-06",
                Senha = "123456"
            };

            Assert.Throws<ArgumentException>(() =>
                                        new User(usuarioEsperado.CPF, nome, usuarioEsperado.Senha)).ComMensagem("Nome inválido");
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void SenhaNaoDeveSerNulaOuVazia(string senha) {
            var usuarioEsperado = new {
                CPF = "453.461.528-06",
                Nome = "Guilherme"
            };

            Assert.Throws<ArgumentException>(() =>
                                new User(usuarioEsperado.CPF, usuarioEsperado.Nome, senha)).ComMensagem("Senha inválida");
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
