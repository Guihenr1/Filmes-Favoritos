using Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.DomainTest._Builder {
    public class UserBuilder {
        private string _cpf = "453.461.528-06";
        private string _nome = "Guilherme";
        private string _senha = "123456";

        public static UserBuilder Novo() {
            return new UserBuilder();
        }
        
        public UserBuilder ComCpf(string cpf) {
            _cpf = cpf;
            return this;
        }

        public UserBuilder ComNome(string nome) {
            _nome = nome;
            return this;
        }

        public UserBuilder ComSenha(string senha) {
            _senha = senha;
            return this;
        }

        public User Build() {
            return new User(_cpf, _nome, _senha);
        }
    }
}
