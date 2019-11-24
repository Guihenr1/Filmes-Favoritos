using Api.Domain._Base;
using System;

namespace Api.Domain.User {
    public class User : Entity {
        private User(){ }
        public User(string cpf, string nome, string senha) {
            if (string.IsNullOrEmpty(cpf))
                throw new ArgumentException(Resource.CPFInvalido);

            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException(Resource.NomeInvalido);

            if (string.IsNullOrEmpty(senha))
                throw new ArgumentException(Resource.SenhaInvalida);

            CPF = cpf;
            Nome = nome;
            Senha = senha;
        }

        public string CPF { get; private set; }
        public string Nome { get; private set; }
        public string Senha { get; private set; }

        public void AlterarCPF(string cpfEsperado) {
            if (string.IsNullOrEmpty(cpfEsperado))
                throw new ArgumentException(Resource.CPFInvalido);

            CPF = cpfEsperado;
        }

        public void AlterarNome(string nomeEsperado) {
            if (string.IsNullOrEmpty(nomeEsperado))
                throw new ArgumentException(Resource.NomeInvalido);

            Nome = nomeEsperado;
        }

        public void AlterarSenha(string senhaEsperada) {
            if (string.IsNullOrEmpty(senhaEsperada))
                throw new ArgumentException(Resource.SenhaInvalida);

            Senha = senhaEsperada;
        }
    }
}
