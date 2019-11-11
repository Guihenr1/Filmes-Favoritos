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
    }

    public class User {
        public string CPF { get; private set; }
        public string Nome { get; private set; }
        public string Senha { get; private set; }

        public User(string cpf, string nome, string senha) {
            CPF = cpf;
            Nome = nome;
            Senha = senha;
        }
    }
}
