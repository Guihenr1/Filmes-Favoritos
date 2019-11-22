using Api.Domain._Base;
using System;

namespace Api.Domain.User {
    public class User : Entity {
        private User(){ }
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
