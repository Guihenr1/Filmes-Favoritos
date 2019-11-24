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
                                    UserBuilder.Novo().ComCpf(cpf).Build()).ComMensagem(Resource.CPFInvalido);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NomeNaoDeveSerVazioOuNulo(string nome) {

            Assert.Throws<ArgumentException>(() =>
                                        UserBuilder.Novo().ComNome(nome).Build()).ComMensagem(Resource.NomeInvalido);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void SenhaNaoDeveSerNulaOuVazia(string senha) {

            Assert.Throws<ArgumentException>(() =>
                                UserBuilder.Novo().ComSenha(senha).Build()).ComMensagem(Resource.SenhaInvalida);
        }

        [Fact]
        public void DevoAlterarCPF() {
            var CPFEsperado = "000.000.000-00";
            var user = UserBuilder.Novo().Build();

            user.AlterarCPF(CPFEsperado);

            Assert.Equal(CPFEsperado, user.CPF);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveAlterarCPF(string CPFInvalido) {
            var user = UserBuilder.Novo().Build();

            Assert.Throws<ArgumentException>(() => user.AlterarCPF(CPFInvalido))
                .ComMensagem(Resource.CPFInvalido);
        }

        [Fact]
        public void DevoAlterarNome() {
            var NomeEsperado = "Guilherme";
            var user = UserBuilder.Novo().Build();

            user.AlterarNome(NomeEsperado);

            Assert.Equal(NomeEsperado, user.Nome);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveAlterarNome(string nomeInvalido) {
            var user = UserBuilder.Novo().Build();

            Assert.Throws<ArgumentException>(() => user.AlterarNome(nomeInvalido))
                .ComMensagem(Resource.NomeInvalido);
        }

        [Fact]
        public void DevoAlterarSenha() {
            var SenhaEsperada = "123ABC";
            var user = UserBuilder.Novo().Build();

            user.AlterarSenha(SenhaEsperada);

            Assert.Equal(SenhaEsperada, user.Senha);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveAlterarSenha(string senhaInvalida) {
            var user = UserBuilder.Novo().Build();

            Assert.Throws<ArgumentException>(() => user.AlterarSenha(senhaInvalida))
                .ComMensagem(Resource.SenhaInvalida);
        }
    }    
}
